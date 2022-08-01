// using BazaarOnline.Application.DTOs.Users.UserDTOs;
// using BazaarOnline.Application.Interfaces.Users;
// using FluentValidation;

// namespace BazaarOnline.Application.FluentValidations
// {
//     public class UserCreateFluentValidation : AbstractValidator<UserCreateDTO>
//     {
//         public UserCreateFluentValidation(IUserService userService)
//         {
//             RuleFor(v => v.Email)
//                 .Must(email => !userService.IsEmailExists(email))
//                 .WithMessage("این ایمیل قبلا ثبت شده است");

//             RuleFor(v => v.PhoneNumber)
//                 .Must(phone => ((string.IsNullOrEmpty(phone)) ? true :
//                        !userService.IsPhoneNumberExists(phone))
//                 )
//                 .WithMessage("این شماره قبلا ثبت شده است");

//         }
//     }
// }

using BazaarOnline.Application.DTOs.Users.UserDTOs;
using BazaarOnline.Application.FluentValidations;
using BazaarOnline.Application.Interfaces.Users;
using FluentValidation.TestHelper;
using Moq;
using NUnit.Framework;
namespace BazaarOnline.Application.UnitTests.FluentValidations.Auth;

[TestFixture]
public class UserCreateFluentValidationTests
{
    private Mock<IUserService> _userMock;
    private UserCreateFluentValidation _validator;

    [SetUp]
    public void SetUp()
    {
        _userMock = new Mock<IUserService>();
        _validator = new UserCreateFluentValidation(_userMock.Object);
    }

    [Test]
    public void Validate_EmailNotExistsAndPhoneNotExists_NoValidationErrorsHappen()
    {
        _userMock.Setup(m => m.IsEmailExists(It.IsAny<string>())).Returns(false);
        _userMock.Setup(m => m.IsPhoneNumberExists(It.IsAny<string>())).Returns(false);

        var result = _validator.TestValidate(new UserCreateDTO { PhoneNumber = "1" });

        result.ShouldNotHaveAnyValidationErrors();
    }


    [Test]
    public void Validate_EmailNotExistsAndPhoneIsNull_NoValidationErrorsHappen()
    {
        _userMock.Setup(m => m.IsEmailExists(It.IsAny<string>())).Returns(false);
        _userMock.Setup(m => m.IsPhoneNumberExists(null)).Returns(true);

        var result = _validator.TestValidate(new UserCreateDTO { PhoneNumber = null });

        result.ShouldNotHaveAnyValidationErrors();
    }


    [Test]
    public void Validate_EmailExistsAndPhoneNotExists_ValidationErrorForEmailOnly()
    {
        _userMock.Setup(m => m.IsEmailExists(It.IsAny<string>())).Returns(true);
        _userMock.Setup(m => m.IsPhoneNumberExists(It.IsAny<string>())).Returns(false);

        var result = _validator.TestValidate(new UserCreateDTO { PhoneNumber = "1" });

        result.ShouldHaveValidationErrorFor(m => m.Email).Only();
    }


    [Test]
    public void Validate_EmailNotExistsAndPhoneExists_ValidationErrorForPhoneOnly()
    {
        _userMock.Setup(m => m.IsEmailExists(It.IsAny<string>())).Returns(false);
        _userMock.Setup(m => m.IsPhoneNumberExists(It.IsAny<string>())).Returns(true);

        var result = _validator.TestValidate(new UserCreateDTO { PhoneNumber = "1" });

        result.ShouldHaveValidationErrorFor(m => m.PhoneNumber).Only();
    }



}
