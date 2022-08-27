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
        public ActionResult Register(UserRegisterDTO registerDTO)
        {
            if (!ModelState.IsValid) return BadRequest(registerDTO);

            var user = _userService.CreateUser(registerDTO);

            return CreatedAtAction(null, null);
        }

        #region JWT

        [HttpPost($"JWT/{nameof(CreateToken)}")]
        public ActionResult<GeneratedTokenDTO> CreateToken(UserLoginDTO loginDTO)
        {
            if (!ModelState.IsValid) return BadRequest(loginDTO);

            var user = _authService.GetUserByCredentials(loginDTO, ModelState);
            if (user == null) return ValidationProblem(ModelState);

            return Ok(_authService.CreateToken(user));
        }

        #endregion

        #region Activation

        [HttpPost(nameof(RegisterActiveCode))]
        public ActionResult<CodeSentResultDTO> RegisterActiveCode(SMSActiveCodeDTO smsDTO)
        {
            if (!ModelState.IsValid) return BadRequest(smsDTO);

            var user = _userService.FindUserByPhone(smsDTO.PhoneNumber);
            var activationResult = _authService.SendRegisterUserSMS(user);

            return Ok(activationResult);
        }


        [HttpPost(nameof(ActivateUser))]
        public ActionResult<OperationResultDTO> ActivateUser(ActivateUserDTO activeDTO)
        {
            if (!ModelState.IsValid) return BadRequest(activeDTO);

            var user = _userService.FindUserByPhone(activeDTO.PhoneNumber);
            _authService.ActivateUser(user);

            return Ok(new OperationResultDTO
            {
                IsSuccess = true,
                Message = "حساب شما فعال شد. هم اکنون می توانید وارد حساب خود شوید"
            });
        }

        [HttpPost(nameof(EmailActiveCode))]
        public ActionResult<CodeSentResultDTO> EmailActiveCode(EmailActiveCodeDTO emailDTO)
        {
            if (!ModelState.IsValid) return BadRequest(emailDTO);

            var user = _userService.FindUser(emailDTO.Email);
            var activationResult = _authService.SendActiveUserEmail(user);

            return Ok(activationResult);
        }


        [HttpPost(nameof(ActivateEmail))]
        public ActionResult<OperationResultDTO> ActivateEmail(ActivateUserEmailDTO activeDTO)
        {
            if (!ModelState.IsValid) return BadRequest(activeDTO);

            var user = _userService.FindUser(activeDTO.Email);
            _authService.ActivateEmail(user);

            return Ok(new OperationResultDTO
            {
                IsSuccess = true,
                Message = "ایمیل شما فعال شد"
            });
        }


        #endregion

    }
}
