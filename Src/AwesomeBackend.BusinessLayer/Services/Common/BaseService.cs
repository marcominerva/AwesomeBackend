using AwesomeBackend.Authentication.Extensions;
using AwesomeBackend.BusinessLayer.Models;
using AwesomeBackend.DataAccessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
