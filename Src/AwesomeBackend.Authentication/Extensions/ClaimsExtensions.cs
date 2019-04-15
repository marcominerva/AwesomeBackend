using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeBackend.Authentication.Extensions
{
    public static class ClaimsExtensions
    {
        public static Guid GetId(this IPrincipal user)
            => Guid.Parse(user.GetValue(JwtRegisteredClaimNames.Sid));

        public static string GetFirstName(this IPrincipal user)
            => user.GetValue(ClaimTypes.GivenName);

        public static string GetLastName(this IPrincipal user)
            => user.GetValue(ClaimTypes.Surname);

        public static string GetUserName(this IPrincipal user)
            => user.GetValue(ClaimTypes.NameIdentifier);

        public static string GetEmail(this IPrincipal user)
            => user.GetValue(ClaimTypes.Email);

        public static string GetValue(this IPrincipal user, string claimType)
        {
            var value = ((ClaimsIdentity)user.Identity).Claims.Where(c => c.Type == claimType).Select(c => c.Value).FirstOrDefault();
            return value;
        }
    }
}
