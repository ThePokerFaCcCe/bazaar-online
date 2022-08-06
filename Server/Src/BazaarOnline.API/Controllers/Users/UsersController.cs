using BazaarOnline.Application.DTOs.PaginationDTO;
using BazaarOnline.Application.DTOs.Users.UserDTOs;
using BazaarOnline.Application.FluentValidations;
using BazaarOnline.Application.Interfaces.Users;
using BazaarOnline.Application.Securities.Attributes;
using BazaarOnline.Application.Validators;
using BazaarOnline.Application.ViewModels.Users.UserViewModels;
using BazaarOnline.Infra.Data.Seeds.DefaultDatas;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;

namespace BazaarOnline.API.Controllers.Users
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [HasPermission(DefaultPermissions.GetUserDetailId)]
        public ActionResult<PaginationResultDTO<UserListDetailViewModel>>
            GetUsersList([FromQuery] UserFilterDTO filter,
                         [FromQuery] PaginationFilterDTO pagination)
        {
            return _userService.GetUserListDetails(filter, pagination);
        }

        [HttpGet("{id}")]
        [HasPermission(DefaultPermissions.GetUserDetailId)]
        public ActionResult<UserDetailViewModel> GetUserDetail(int id)
        {
            var userDetail = _userService.GetUserDetail(id);
            if (userDetail == null) return NotFound();

            return Ok(userDetail);
        }

        [HttpGet("Find/{email}")]
        [HasPermission(DefaultPermissions.GetUserDetailId)]
        public ActionResult<UserDetailViewModel> FindUserDetail(string email)
        {
            if (!StringValidator.IsValidEmail(email)) return NotFound();
            var userDetail = _userService.GetUserDetail(email);
            if (userDetail == null) return NotFound();

            return Ok(userDetail);
        }

        [HttpPost]
        [HasPermission(DefaultPermissions.CreateUserId)]
        public ActionResult CreateUser([FromBody] UserCreateDTO createDTO)
        {
            if (!ModelState.IsValid) return BadRequest(createDTO);

            var user = _userService.CreateUser(createDTO);
            return CreatedAtAction(nameof(GetUserDetail), new { Id = user.Id }, null);

        }

        [HttpPut("{id}")]
        [HasPermission(DefaultPermissions.UpdateUserId)]
        public ActionResult UpdateUser(int id, [FromBody][CustomizeValidator(Skip = true)] UserUpdateDTO updateDTO)
        {
            if (!ModelState.IsValid) return BadRequest(updateDTO);

            var user = _userService.FindUser(id);
            if (user == null) return NotFound();

            if (updateDTO.Email.ToLower().Trim() == user.Email)
                updateDTO.Email = null;

            if (updateDTO.PhoneNumber == user.PhoneNumber)
                updateDTO.PhoneNumber = null;

            var validator = new UserUpdateFluentValidation(_userService);
            var result = validator.Validate(updateDTO);
            if (!result.IsValid)
            {
                result.AddToModelState(ModelState, string.Empty);
                return ValidationProblem(ModelState);
            }

            _userService.UpdateUser(user, updateDTO);
            return Ok();
        }

        [HttpDelete("{id}")]
        [HasPermission(DefaultPermissions.DeleteUserId)]
        public ActionResult DeleteUser(int id)
        {
            var user = _userService.FindUser(id);
            if (user == null) return NotFound();

            _userService.SoftDeleteUser(user);
            return NoContent();
        }
    }
}
