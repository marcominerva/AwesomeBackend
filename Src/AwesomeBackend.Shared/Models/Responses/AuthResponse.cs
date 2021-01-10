using System;

namespace AwesomeBackend.Shared.Models.Responses
{
    public class AuthResponse
    {
        public string Token { get; }

        public DateTime Expiration { get; }

        public AuthResponse(string token, DateTime expiration)
        {
            Token = token;
            Expiration = expiration;
        }
    }
}
