using BazaarOnline.Application.DTOs.AuthDTOs;
using BazaarOnline.Application.Interfaces.Users;
using FluentValidation;

namespace BazaarOnline.Application.FluentValidations.Auth
{
    public class ActivateUserEmailFluentValidation : AbstractValidator<ActivateUserEmailDTO>
    {
        public ActivateUserEmailFluentValidation(IUserService userService, IActiveCodeService activeCodeService)
        {
            RuleFor(v => v.Email)
                .Must(email => userService.IsInactiveEmailExists(email))
                .WithMessage("ایمیل غیرفعال یافت نشد")
                .DependentRules(() =>
                {
                    RuleFor(v => v.Code)
                        .Must((v, code) => activeCodeService.IsEmailActiveCodeExists(v.Email, code))
                        .WithMessage("کد فعالسازی وارد شده یافت نشد");
                });

        }
    }
}
