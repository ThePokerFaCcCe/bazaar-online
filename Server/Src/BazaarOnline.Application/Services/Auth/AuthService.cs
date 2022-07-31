using BazaarOnline.Application.DTOs;
using BazaarOnline.Application.DTOs.AuthDTOs;
using BazaarOnline.Application.Interfaces.Auth;
using BazaarOnline.Application.Interfaces.Users;
using BazaarOnline.Application.Securities;
using BazaarOnline.Application.Senders;
using BazaarOnline.Domain.Entities.Users;
using Microsoft.Extensions.Configuration;
using Testing.Application.DTOs.JwtDTOs;

namespace BazaarOnline.Application.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IActiveCodeService _activeCodeService;
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;
        public AuthService(IActiveCodeService activeCodeService, IUserService userService, IConfiguration configuration)
        {
            _activeCodeService = activeCodeService;
            _userService = userService;
            _configuration = configuration;
        }

        public OperationResultDTO ActivateUserByCode(User user, string code)
        {
            var activeCode = _activeCodeService.GetActiveCode(user.Email, code);
            if (activeCode == null)
                return new OperationResultDTO
                {
                    Message = "کد وارد شده یافت نشد"
                };

            user.IsActive = true;
            _userService.UpdateUser(user);

            return new OperationResultDTO
            {
                IsSuccess = true,
                Message = "حساب شما فعال شد. هم اکنون می توانید وارد حساب خود شوید"
            };
        }

        public GeneratedTokenDTO CreateToken(User user)
        {
            string issuer = _configuration["JwtSettings:Issuer"];
            string encKey = System.Environment.GetEnvironmentVariable("JWT__SIGNKEY");
            string signKey = System.Environment.GetEnvironmentVariable("JWT__ENCRYPTKEY");
            int expireMinutes = _configuration.GetValue<int>("JwtSettings:ExpireMinutes");

            return JWTAuthorization.GenerateToken(user, issuer, signKey, encKey, expireMinutes);
        }

        public CodeSentResultDTO RegisterUserByEmail(User user)
        {
            var activeCode = _activeCodeService.CreateActiveCode(user.Email);

            EmailSender.SendActiveCode(user, activeCode);

            return new CodeSentResultDTO
            {
                Message = $"کد تایید به ایمیل {user.Email} ارسال شد",
                ExpireDate = activeCode.ExpireDate
            };
        }
    }
}
