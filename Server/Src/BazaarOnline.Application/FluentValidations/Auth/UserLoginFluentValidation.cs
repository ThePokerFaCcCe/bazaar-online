using BazaarOnline.Application.DTOs.AuthDTOs;
using BazaarOnline.Application.Interfaces.Users;
using FluentValidation;

namespace BazaarOnline.Application.FluentValidations
{
    public class UserLoginFluentValidation : AbstractValidator<UserLoginDTO>
    {
        public UserLoginFluentValidation(IUserService _userService)
        {
            RuleFor(v => v.Email)
                .Must((v, email) => _userService.ComparePassword(email, v.Password))
                .WithMessage("اطلاعات وارد شده صحیح نیست");
        }
    }
}
