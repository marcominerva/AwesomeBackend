using AwesomeBackend.Authentication.Extensions;
using AwesomeBackend.DataAccessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;

namespace AwesomeBackend.BusinessLayer.Services.Common
{
    public abstract class BaseService
    {
        protected IApplicationDbContext DataContext { get; }

        protected HttpContext HttpContext { get; }

        protected ILogger Logger { get; }

        protected IServiceProvider ServiceProvider { get; }

        protected Guid? UserId => HttpContext?.User.GetId();

        public BaseService(IApplicationDbContext dataContext, IHttpContextAccessor httpContextAccessor, ILogger logger, IServiceProvider serviceProvider)
        {
            DataContext = dataContext;
            HttpContext = httpContextAccessor.HttpContext;
            Logger = logger;
            ServiceProvider = serviceProvider;
        }
    }
}
