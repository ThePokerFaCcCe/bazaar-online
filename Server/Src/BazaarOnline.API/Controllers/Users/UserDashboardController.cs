using BazaarOnline.Application.DTOs.Users.UserDashboardDTOs;
using BazaarOnline.Application.Interfaces.Users;
using BazaarOnline.Application.ViewModels.Users.UserDashboardViewModels;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BazaarOnline.API.Controllers.Users
{
    [Route("api/Users/Me")]
    [ApiController]
    [Authorize]
    public class UserDashboardController : ControllerBase
    {
        private readonly IUserDashboardService _userDashboardService;

        public UserDashboardController(IUserDashboardService userDashboardService)
        {
            _userDashboardService = userDashboardService;
        }

        [HttpGet]
        public ActionResult<UserDashboardDetailViewModel> GetUserDetail()
        {
            int.TryParse(User.Identity.Name, out int userId);
            return _userDashboardService.GetUserDashboardDetail(userId);
        }

        [HttpPut()]
        public ActionResult UpdateUser(
            [FromBody][CustomizeValidator(Skip = true)] UserDashboardUpdateDTO updateDTO)
        {
            var user = _userDashboardService.GetAuthorizedUser(User);
            if (user == null) return Unauthorized();

            if (!ModelState.IsValid) return BadRequest(updateDTO);

            _userDashboardService.UpdateUser(user, updateDTO);
            return Ok();
        }
    }
}
