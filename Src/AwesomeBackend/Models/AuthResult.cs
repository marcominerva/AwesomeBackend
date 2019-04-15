using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeBackend.Models
{
    public class AuthResult
    {
        public string Token { get; }

        public DateTime Expiration { get; }

        public AuthResult(string token, DateTime expiration)
        {
            Token = token;
            Expiration = expiration;
        }
    }
}
