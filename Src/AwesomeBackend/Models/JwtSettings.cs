using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeBackend.Models
{
    public class JwtSettings
    {
		public string SecurityKey { get; set; }

		public string Issuer { get; set; }

		public string Audience { get; set; }

        public int ExpirationMinutes { get; set; }
    }
}
