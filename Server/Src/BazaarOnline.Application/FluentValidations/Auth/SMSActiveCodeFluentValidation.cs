using BazaarOnline.Application.DTOs.AuthDTOs;
using BazaarOnline.Application.Interfaces.Users;
using FluentValidation;

namespace BazaarOnline.Application.FluentValidations
{
    public class SMSActiveCodeFluentValidation : AbstractValidator<SMSActiveCodeDTO>
    {
        public SMSActiveCodeFluentValidation(IActiveCodeService activeCodeService, IUserService userService)
        {
            RuleFor(v => v.PhoneNumber)
                .Must(phone => userService.IsInactiveUserExists(phone))
                .WithMessage("کاربر غیرفعال با این شماره یافت نشد")
                .DependentRules(() =>
                {
                    RuleFor(v => v.PhoneNumber)
                        .Must(phone => !activeCodeService.IsPhoneActiveCodeExists(phone))
                        .WithMessage("کد فعالسازی برای شما ارسال شده است");
                });
        }
    }
}
