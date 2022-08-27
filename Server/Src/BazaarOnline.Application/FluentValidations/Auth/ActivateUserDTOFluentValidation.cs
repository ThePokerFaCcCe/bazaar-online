using BazaarOnline.Application.DTOs.AuthDTOs;
using BazaarOnline.Application.Interfaces.Users;
using FluentValidation;

namespace BazaarOnline.Application.FluentValidations.Auth
{
    public class ActivateUserDTOFluentValidation : AbstractValidator<ActivateUserDTO>
    {
        public ActivateUserDTOFluentValidation(IUserService userService, IActiveCodeService activeCodeService)
        {
            RuleFor(v => v.PhoneNumber)
                .Must(phone => userService.IsInactiveUserExists(phone))
                .WithMessage("کاربر غیرفعال با این شماره یافت نشد")
                .DependentRules(() =>
                {
                    RuleFor(v => v.Code)
                        .Must((v, code) => activeCodeService.IsPhoneActiveCodeExists(v.PhoneNumber, code))
                        .WithMessage("کد فعالسازی وارد شده یافت نشد");
                });

        }
    }
}
