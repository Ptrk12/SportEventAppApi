using Managers.managers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SportEventAppApi.Controllers
{
    [Route("/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserManager _userManager;

        public UserController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        ///<summary>
        ///  Get current logged user informations
        /// </summary>
        /// <response code="200">Success</response>
        [HttpGet]
        [Authorize]
        [Route("user-info")]
        public async Task<IActionResult> GetCurrentLoggedUserEventsAssignedTo()
        {
            var result = await _userManager.GetUserInfo();
            return Ok(result);
        }
    }
}
