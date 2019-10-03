using AwesomeBackend.Authentication.Extensions;
using AwesomeBackend.DataAccessLayer;
using Microsoft.AspNetCore.Http;
using System;

namespace AwesomeBackend.BusinessLayer.Services.Common
{
    public abstract class BaseService
    {
        protected IApplicationDbContext DataContext { get; }

        protected HttpContext HttpContext { get; }

        protected IServiceProvider ServiceProvider { get; }

        protected Guid? UserId => HttpContext?.User.GetId();

        public BaseService(IApplicationDbContext dataContext, IHttpContextAccessor httpContextAccessor, IServiceProvider serviceProvider)
        {
            DataContext = dataContext;
            HttpContext = httpContextAccessor.HttpContext;
            ServiceProvider = serviceProvider;
        }
    }
}
