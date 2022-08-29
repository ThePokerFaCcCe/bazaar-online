using BazaarOnline.Application.DTOs.AuthDTOs;
using BazaarOnline.Application.DTOs.JwtDTOs;
using BazaarOnline.Application.Generators;
using BazaarOnline.Application.Interfaces.Auth;
using BazaarOnline.Application.Interfaces.Senders;
using BazaarOnline.Application.Securities;
using BazaarOnline.Domain.Entities.Users;
using BazaarOnline.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
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

        public void ActivateUser(User user)
        {
            user.IsActive = true;
            _repository.Update<User>(user);
            _repository.Save();
        }

        public void ActivateEmail(User user)
        {
            user.IsEmailActive = true;
            _repository.Update<User>(user);
            _repository.Save();
        }

        public CodeSentResultDTO SendRegisterUserSMS(User user)
        {
            int expireMinutes = _configuration.GetValue<int>("Settings:ActiveCodeExpireMinutes:SMS", 1);
            var activeCode = _repository.Add<ActiveCode>(new ActiveCode
            {
                UserId = user.Id,
                Code = StringGenerator.GenerateActiveCode(),
                Type = ActiveCodeType.UserActivation,
                ExpireDate = DateTime.Now.AddMinutes(expireMinutes),
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
            int expireMinutes = _configuration.GetValue<int>("Settings:ActiveCodeExpireMinutes:Email", 1);
            var activeCode = _repository.Add<ActiveCode>(new ActiveCode
            {
                UserId = user.Id,
                Code = StringGenerator.GenerateActiveCode(),
                Type = ActiveCodeType.EmailActivation,
                ExpireDate = DateTime.Now.AddMinutes(expireMinutes),
            });
            _repository.Save();

            _emailService.SendActiveCode(user, activeCode);

            return new CodeSentResultDTO
            {
                Message = $"کد تایید به ایمیل {user.Email} ارسال شد",
                ExpireDate = activeCode.ExpireDate
            };
        }

        public User? GetUserByCredentials(UserLoginDTO loginDTO, ModelStateDictionary ModelState)
        {
            var user = _repository.GetAll<User>()
                .SingleOrDefault(u => u.PhoneNumber == loginDTO.PhoneNumber);

            if (user == null)
            {
                ModelState.AddModelError(nameof(loginDTO.PhoneNumber), "حساب کاربری با این شماره یافت نشد");
                return null;
            }

            if (!user.IsActive)
            {
                ModelState.AddModelError(nameof(loginDTO.PhoneNumber), "حساب کاربری فعال نیست");
                return null;
            }

            if (!PasswordHelper.VerifyPassword(loginDTO.Password, user.Password))
            {
                ModelState.AddModelError(nameof(loginDTO.Password), "رمز عبور معتبر نیست");
                return null;
            }
            return user;
        }
    }
}
