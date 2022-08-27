using BazaarOnline.Application.DTOs.AuthDTOs;
using BazaarOnline.Application.DTOs.JwtDTOs;
using BazaarOnline.Application.Generators;
using BazaarOnline.Application.Interfaces.Auth;
using BazaarOnline.Application.Interfaces.Senders;
using BazaarOnline.Application.Securities;
using BazaarOnline.Domain.Entities.Users;
using BazaarOnline.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace BazaarOnline.Application.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IRepository _repository;
        private readonly IConfiguration _configuration;
        private readonly ISMSService _smsService;
        private readonly IEmailService _emailService;
        public AuthService(IConfiguration configuration, IRepository repository, ISMSService smsService, IEmailService emailService)
        {
            _configuration = configuration;
            _repository = repository;
            _smsService = smsService;
            _emailService = emailService;
        }


        public GeneratedTokenDTO CreateToken(User user)
        {
            string issuer = _configuration["JwtSettings:Issuer"];
            string encKey = System.Environment.GetEnvironmentVariable("JWT__SIGNKEY");
            string signKey = System.Environment.GetEnvironmentVariable("JWT__ENCRYPTKEY");
            int expireMinutes = _configuration.GetValue<int>("JwtSettings:ExpireMinutes");

            return JWTAuthorization.GenerateToken(user, issuer, signKey, encKey, expireMinutes);
        }

        public CodeSentResultDTO SendRegisterUserSMS(User user)
        {
            var activeCode = _repository.Add<ActiveCode>(new ActiveCode
            {
                UserId = user.Id,
                Code = StringGenerator.GenerateActiveCode(),
                ExpireDate = DateTime.Now.AddMinutes(1)
            });
            _repository.Save();

            var result = _smsService.SendActiveCode(user, activeCode);
            if (!result)
                return new CodeSentResultDTO
                {
                    Message = "خطایی رخ داده است. لطفا مجددا تلاش کنید",
                };
            else
                return new CodeSentResultDTO
                {
                    Message = $"کد تایید به شماره {user.PhoneNumber} ارسال شد",
                    ExpireDate = activeCode.ExpireDate
                };
        }

        public CodeSentResultDTO SendActiveUserEmail(User user)
        {
            var activeCode = _repository.Add<ActiveCode>(new ActiveCode
            {
                UserId = user.Id,
                Code = StringGenerator.GenerateActiveCode(),
                ExpireDate = DateTime.Now.AddMinutes(1)
            });
            _repository.Save();

            _emailService.SendActiveCode(user, activeCode);

            return new CodeSentResultDTO
            {
                Message = $"کد تایید به ایمیل {user.Email} ارسال شد",
                ExpireDate = activeCode.ExpireDate
            };
        }
    }
}
