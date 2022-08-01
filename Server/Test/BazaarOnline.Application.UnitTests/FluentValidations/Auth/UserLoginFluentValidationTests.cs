using BazaarOnline.Application.DTOs.AuthDTOs;
using BazaarOnline.Application.FluentValidations;
using BazaarOnline.Application.Interfaces.Users;
using FluentValidation.TestHelper;
using Moq;
using NUnit.Framework;
namespace BazaarOnline.Application.UnitTests.FluentValidations.Auth;

[TestFixture]
public class UserLoginFluentValidationTests
{
    private Mock<IUserService> _userMock;
    private UserLoginFluentValidation _validator;

    [SetUp]
    public void SetUp()
    {
        _userMock = new Mock<IUserService>();
        _validator = new UserLoginFluentValidation(_userMock.Object);
    }

    [Test]
    public void Validate_EmailOrPasswordWrong_ValidationErrorForEmailOnly()
    {
        _userMock.Setup(m => m.ComparePassword(It.IsAny<string>(), It.IsAny<string>())).Returns(false);

        var result = _validator.TestValidate(new UserLoginDTO());

        result.ShouldHaveValidationErrorFor(m => m.Email).Only();
    }


    [Test]
    public void Validate_EmailAndPasswordOk_NoValidationErrorsHappen()
    {
        _userMock.Setup(m => m.ComparePassword(It.IsAny<string>(), It.IsAny<string>())).Returns(true);

        var result = _validator.TestValidate(new UserLoginDTO());

        result.ShouldNotHaveAnyValidationErrors();
    }






}
