using BazaarOnline.Application.DTOs.Users.UserDTOs;
using BazaarOnline.Application.Interfaces.Users;
using FluentValidation;

namespace BazaarOnline.Application.FluentValidations
{
    public class UserCreateFluentValidation : AbstractValidator<UserCreateDTO>
    {
        public UserCreateFluentValidation(IUserService userService)
        {
            RuleFor(v => v.Email)
                .Must(email => !userService.IsEmailExists(email))
                .WithMessage("این ایمیل قبلا ثبت شده است");

            RuleFor(v => v.PhoneNumber)
                .Must(phone => (!string.IsNullOrEmpty(phone)
                      && !userService.IsPhoneNumberExists(phone))
                )
                .WithMessage("این شماره قبلا ثبت شده است");

        }
    }
}
