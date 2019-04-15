using AwesomeBackend.Authentication.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeBackend.Authentication
{
    public class AuthenticationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        //public AuthenticationDbContext(DbContextOptions<AuthenticationDbContext> options)
        //    : base(options)
        //{
        //}

        public AuthenticationDbContext(DbContextOptions options)
            : base(options)
        {
        }
    }
}
