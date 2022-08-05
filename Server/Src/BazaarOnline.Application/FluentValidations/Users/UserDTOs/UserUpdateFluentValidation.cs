using BazaarOnline.Application.DTOs.Users.UserDTOs;
using BazaarOnline.Application.Interfaces.Users;
using FluentValidation;

namespace BazaarOnline.Application.FluentValidations
{
    public class UserUpdateFluentValidation : AbstractValidator<UserUpdateDTO>
    {
        public UserUpdateFluentValidation(IUserService userService)
        {
            RuleFor(v => v.Email)
                .Must(email => ((string.IsNullOrEmpty(email)) ? true :
                    !userService.IsEmailExists(email)))
                .WithMessage("این ایمیل قبلا ثبت شده است");

            RuleFor(v => v.PhoneNumber)
                .Must(phone => ((string.IsNullOrEmpty(phone)) ? true :
                       !userService.IsPhoneNumberExists(phone))
                )
                .WithMessage("این شماره قبلا ثبت شده است");
        }
    }
}
