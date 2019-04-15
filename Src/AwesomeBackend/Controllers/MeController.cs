using AwesomeBackend.Authentication.Extensions;
using AwesomeBackend.BusinessLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AwesomeBackend.Controllers
{
    [Authorize]
    public class MeController : ControllerBase
    {
        /// <summary>
        /// Recupera le informazioni sull'utente corrente
        /// </summary>
        /// <response code="200">Le informazioni sull'utente attualmente loggato</response>
        /// <response code="401">Utente non autorizzato</response>
        [HttpGet]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
        public ActionResult<User> Get()
        {
            // Recupera le informazioni dell'utente corrente dai claim.
            return new User
            {
                Id = User.GetId(),
                UserName = User.GetUserName(),
                FirstName = User.GetFirstName(),
                LastName = User.GetLastName(),
                Email = User.GetEmail()
            };
        }
    }
}
