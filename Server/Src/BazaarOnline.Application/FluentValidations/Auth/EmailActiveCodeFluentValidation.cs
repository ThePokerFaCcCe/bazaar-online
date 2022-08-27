using BazaarOnline.Application.DTOs.AuthDTOs;
using BazaarOnline.Application.Interfaces.Users;
using FluentValidation;

namespace BazaarOnline.Application.FluentValidations
{
    public class EmailActiveCodeFluentValidation : AbstractValidator<EmailActiveCodeDTO>
    {
        public EmailActiveCodeFluentValidation(IActiveCodeService activeCodeService, IUserService userService)
        {
            RuleFor(v => v.Email)
                .Must(email => userService.IsInactiveEmailExists(email))
                .WithMessage("ایمیل غیرفعال یافت نشد")
                .DependentRules(() =>
                {
                    RuleFor(v => v.Email)
                        .Must(email => !activeCodeService.IsEmailActiveCodeExists(email))
                        .WithMessage("کد فعالسازی برای شما ارسال شده است");
                });
        }
    }
}
