using AwesomeBackend.Authentication;
using AwesomeBackend.Authentication.Models;
using AwesomeBackend.BusinessLayer.Services;
using AwesomeBackend.DataAccessLayer;
using AwesomeBackend.Documentation;
using AwesomeBackend.Models;
using Hellang.Middleware.ProblemDetails;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Reflection;
using System.Text;

namespace AwesomeBackend
{
    /// <summary>
    /// Represents the startup process for the application.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="configuration">The current configuration.</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Gets the current configuration.
        /// </summary>
        /// <value>The current application configuration.</value>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Configures services for the application.
        /// </summary>
        /// <param name="services">The collection of services to configure the application with.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddControllers();

            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<IApplicationDbContext, ApplicationDbContext>(options => options.UseSqlServer(connectionString));
            services.AddDbContext<AuthenticationDbContext>(options => options.UseSqlServer(connectionString));

            services.AddIdentity<ApplicationUser, ApplicationRole>(setup =>
            {
                setup.Password.RequiredLength = 6;
                setup.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<AuthenticationDbContext>();

            // Get JWT token settings.
            var jwtSection = Configuration.GetSection(nameof(JwtSettings));
            var jwtSettings = jwtSection.Get<JwtSettings>();
            services.Configure<JwtSettings>(jwtSection);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(configureOptions =>
            {
                configureOptions.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidAudience = jwtSettings.Audience,
                    ValidIssuer = jwtSettings.Issuer,
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.Default.GetBytes(jwtSettings.SecurityKey)),
                    LifetimeValidator = (DateTime? notBefore, DateTime? expires, SecurityToken securityToken, TokenValidationParameters validationParameters) => DateTime.UtcNow < expires.GetValueOrDefault(),
                };
            });

            services.AddApiVersioning(options =>
            {
                // reporting api versions will return the headers "api-supported-versions" and "api-deprecated-versions"
                options.ReportApiVersions = true;
            });

            services.AddVersionedApiExplorer(options =>
            {
                // add the versioned api explorer, which also adds IApiVersionDescriptionProvider service
                // note: the specified format code will format the version as "'v'major[.minor][-status]"
                options.GroupNameFormat = "'v'VVV";

                // note: this option is only necessary when versioning by url segment. the SubstitutionFormat
                // can also be used to control the format of the API version in route templates
                options.SubstituteApiVersionInUrl = true;
            });

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            services.AddSwaggerGen(options =>
            {
                // Add a custom operation filter which sets default values
                options.OperationFilter<SwaggerDefaultValues>();

                options.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme { In = ParameterLocation.Header, Description = "Insert JWT token with the \"Bearer \" prefix", Name = "Authorization", Type = SecuritySchemeType.ApiKey });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = JwtBearerDefaults.AuthenticationScheme }
                        },
                        new string[0]
                    }
                });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);

                options.CustomOperationIds(apiDesc =>
                {
                    return $"{apiDesc.ActionDescriptor.RouteValues["controller"]}_{apiDesc.ActionDescriptor.RouteValues["action"]}";
                });
            });

            // Configure error handling according to RFC7807.
            // https://codeopinion.com/http-api-problem-details-in-asp-net-core/
            services.AddProblemDetails();

            services.AddHealthChecks() // Registers health check services
                .AddAsyncCheck("sql", async () =>
                {
                    try
                    {
                        using var connection = new SqlConnection(connectionString);
                        await connection.OpenAsync();
                    }
                    catch (Exception ex)
                    {
                        return HealthCheckResult.Unhealthy(ex.Message, ex);
                    }

                    return HealthCheckResult.Healthy();
                });

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                builder =>
                {
                    builder.AllowAnyOrigin();
                    builder.AllowAnyHeader();
                    builder.AllowAnyMethod();
                });
            });

            // Add service specific services.
            services.AddScoped<IRestaurantsService, RestaurantsService>();
            services.AddScoped<IRatingsService, RatingsService>();
        }

        /// <summary>
        /// This method gets called by the runtime. Configures the application using the provided builder, hosting environment, and API version description provider.
        /// </summary>
        /// <param name="app">The current application builder.</param>
        /// <param name="env">The current hosting environment.</param>
        /// <param name="provider">The API version descriptor provider used to enumerate defined API versions.</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            // Add the middleware to handle errors according to RFC7807.
            app.UseProblemDetails();

            app.UseHttpsRedirection();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(options =>
            {
                // build a swagger endpoint for each discovered API version
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName);
                    options.RoutePrefix = string.Empty;
                }
            });

            // Add the EndpointRoutingMiddleware.
            app.UseRouting();

            // All middleware from here onwards know which endpoint will be invoked.
            app.UseCors("AllowAll");

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

                endpoints.MapHealthChecks("/status",
                   new HealthCheckOptions
                   {
                       ResponseWriter = async (context, report) =>
                       {
                           var result = System.Text.Json.JsonSerializer.Serialize(
                               new
                               {
                                   status = report.Status.ToString(),
                                   details = report.Entries.Select(e => new
                                   {
                                       service = e.Key,
                                       status = Enum.GetName(typeof(HealthStatus), e.Value.Status),
                                       description = e.Value.Description
                                   })
                               });

                           context.Response.ContentType = MediaTypeNames.Application.Json;
                           await context.Response.WriteAsync(result);
                       }
                   });
            });
        }
    }
}
