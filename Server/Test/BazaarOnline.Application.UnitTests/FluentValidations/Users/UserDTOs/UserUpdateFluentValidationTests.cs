using BazaarOnline.Application.DTOs.Users.UserDTOs;
using BazaarOnline.Application.FluentValidations;
using BazaarOnline.Application.Interfaces.Users;
using FluentValidation.TestHelper;
using Moq;
using NUnit.Framework;
namespace BazaarOnline.Application.UnitTests.FluentValidations.Auth;

[TestFixture]
public class UserUpdateFluentValidationTests
{
    private Mock<IUserService> _userMock;
    private UserUpdateFluentValidation _validator;

    [SetUp]
    public void SetUp()
    {
        _userMock = new Mock<IUserService>();
        _validator = new UserUpdateFluentValidation(_userMock.Object);
    }

    [Test]
    public void Validate_EmailNotExistsAndPhoneNotExists_NoValidationErrorsHappen()
    {
        _userMock.Setup(m => m.IsEmailExists(It.IsAny<string>())).Returns(false);
        _userMock.Setup(m => m.IsPhoneNumberExists(It.IsAny<string>())).Returns(false);

        var result = _validator.TestValidate(new UserUpdateDTO { PhoneNumber = "1" });

        result.ShouldNotHaveAnyValidationErrors();
    }


    [Test]
    public void Validate_EmailNotExistsAndPhoneIsNull_NoValidationErrorsHappen()
    {
        _userMock.Setup(m => m.IsEmailExists(It.IsAny<string>())).Returns(false);
        _userMock.Setup(m => m.IsPhoneNumberExists(null)).Returns(true);

        var result = _validator.TestValidate(new UserUpdateDTO { PhoneNumber = null });

        result.ShouldNotHaveAnyValidationErrors();
    }


    [Test]
    public void Validate_EmailNotExistsAndPhoneExists_ValidationErrorForPhoneOnly()
    {
        _userMock.Setup(m => m.IsEmailExists(It.IsAny<string>())).Returns(false);
        _userMock.Setup(m => m.IsPhoneNumberExists(It.IsAny<string>())).Returns(true);

        var result = _validator.TestValidate(new UserUpdateDTO { PhoneNumber = "1" });

        result.ShouldHaveValidationErrorFor(m => m.PhoneNumber).Only();
    }



}
