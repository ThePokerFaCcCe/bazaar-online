using BazaarOnline.Application.DTOs;
using BazaarOnline.Application.DTOs.AuthDTOs;
using BazaarOnline.Application.DTOs.JwtDTOs;
using BazaarOnline.Application.DTOs.Users.UserDTOs;
using BazaarOnline.Application.Interfaces.Auth;
using BazaarOnline.Application.Interfaces.Users;
using Microsoft.AspNetCore.Mvc;

namespace BazaarOnline.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IUserService _userService;

        public AuthController(IAuthService authService, IUserService userService)
        {
            _authService = authService;
            _userService = userService;
        }

        [HttpPost(nameof(Register))]
        public ActionResult Register(UserCreateDTO userDTO)
        {
            if (!ModelState.IsValid) return BadRequest(userDTO);

            var user = _userService.CreateUser(userDTO);

            return CreatedAtAction(null, null);
        }

        #region JWT

        [HttpPost($"JWT/{nameof(CreateToken)}")]
        public ActionResult<GeneratedTokenDTO> CreateToken(UserLoginDTO loginDTO)
        {
            if (!ModelState.IsValid) return BadRequest(loginDTO);

            var user = _userService.FindUser(loginDTO.Email);

            return Ok(_authService.CreateToken(user));
        }

        #endregion

        #region Activation

        [HttpPost(nameof(EmailActiveCode))]
        public ActionResult<CodeSentResultDTO> EmailActiveCode(EmailActiveCodeDTO emailDTO)
        {
            if (!ModelState.IsValid) return BadRequest(emailDTO);

            var user = _userService.FindUser(emailDTO.Email);
            var activationResult = _authService.RegisterUserByEmail(user);

            return Ok(activationResult);
        }


        [HttpPost(nameof(Activate))]
        public ActionResult<OperationResultDTO> Activate(ActivateUserEmailDTO activeDTO)
        {
            if (!ModelState.IsValid) return BadRequest(activeDTO);

            var user = _userService.FindUser(activeDTO.Email);
            _userService.ActivateUser(user);

            return Ok(new OperationResultDTO
            {
                IsSuccess = true,
                Message = "حساب شما فعال شد. هم اکنون می توانید وارد حساب خود شوید"
            });
        }


        #endregion

    }
}
