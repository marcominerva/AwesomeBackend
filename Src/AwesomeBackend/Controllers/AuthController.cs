using AwesomeBackend.Authentication.Models;
using AwesomeBackend.Models;
using AwesomeBackend.Models.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeBackend.Controllers
{
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IPasswordHasher<ApplicationUser> passwordHasher;
        private readonly JwtSettings jwtSettings;

        public AuthController(UserManager<ApplicationUser> userManager, IPasswordHasher<ApplicationUser> passwordHasher, IOptions<JwtSettings> jwtSettings)
        {
            this.userManager = userManager;
            this.passwordHasher = passwordHasher;
            this.jwtSettings = jwtSettings.Value;
        }

        /// <summary>
        /// Effettua la registrazione dell'utente
        /// </summary>
        /// <param name="model">I dati per la registrazione dell'utente.</param>
        /// <response code="200">Registrazione avvenuta con successo</response>
        /// <response code="400">Impossibile registrare l'utente a causa di uno o più erorri dei dati di input</response>
        [HttpPost]
        [Route("register")]
        [ProducesResponseType(typeof(IdentityResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(IEnumerable<IdentityError>), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Register(RegisterRequest model)
        {
            var user = new ApplicationUser()
            {
                UserName = model.Email,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName
            };

            var result = await userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                return Ok(result);
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("error", error.Description);
            }

            return BadRequest(result.Errors);
        }

        /// <summary>
        /// Effettua il login
        /// </summary>
        /// <param name="model">Oggetto che contiene nome utente e password per l'accesso.</param>
        /// <returns>Se il login ha esito positivo, un oggetto che contiene il Bearer token di autenticazione.</returns>
        /// <response code="200">Login effettuato con successo</response>
        /// <response code="400">Impossibile effettuare il login a causa di uno o più erorri dei dati di input</response>
        /// <response code="401">Password non valida</response>
        [HttpPost()]
        [Route("token")]
        [ProducesResponseType(typeof(AuthResult), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<AuthResult>> CreateToken(LoginRequest model)
        {
            var user = await userManager.FindByNameAsync(model.Email);
            if (user == null)
            {
                return BadRequest();
            }

            if (passwordHasher.VerifyHashedPassword(user, user.PasswordHash, model.Password) == PasswordVerificationResult.Success)
            {
                var userClaims = await userManager.GetClaimsAsync(user);
                var userRoles = await userManager.GetRolesAsync(user);

                var claims = new[]
                {
                        new Claim(JwtRegisteredClaimNames.Sid, user.Id.ToString()),
                        new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Email, user.Email),
                        new Claim(JwtRegisteredClaimNames.GivenName, user.FirstName),
                        new Claim(JwtRegisteredClaimNames.FamilyName, user.LastName ?? string.Empty)
                    }.Union(userRoles.Select(role => new Claim(ClaimTypes.Role, role)))
                .Union(userClaims);

                var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecurityKey));
                var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

                var jwtSecurityToken = new JwtSecurityToken(
                    issuer: jwtSettings.Issuer,
                    audience: jwtSettings.Audience,
                    claims: claims,
                    notBefore: DateTime.UtcNow,
                    expires: DateTime.UtcNow.AddMinutes(jwtSettings.ExpirationMinutes),
                    signingCredentials: signingCredentials
                    );

                var result = new AuthResult(new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken), jwtSecurityToken.ValidTo);
                return Ok(result);
            }

            return Unauthorized();
        }
    }
}
