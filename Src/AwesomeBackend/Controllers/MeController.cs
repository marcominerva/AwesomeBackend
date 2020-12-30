using AwesomeBackend.Authentication.Extensions;
using AwesomeBackend.Common.Models.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AwesomeBackend.Controllers
{
    [Authorize]
    public class MeController : ControllerBase
    {
        /// <summary>
        /// Return information about the currently logged user
        /// </summary>
        /// <response code="200">An object containing the information about the currently logged user</response>
        /// <response code="401">Unauthorized user</response>
        [HttpGet]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
        public ActionResult<User> Get()
        {
            // Get User information from claims
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
