using BazaarOnline.Application.DTOs.AuthDTOs;
using BazaarOnline.Application.FluentValidations;
using BazaarOnline.Application.Interfaces.Users;
using FluentValidation.TestHelper;
using Moq;
using NUnit.Framework;
namespace BazaarOnline.Application.UnitTests.FluentValidations.Auth;

[TestFixture]
public class EmailActiveCodeFluentValidationTests
{
    private Mock<IActiveCodeService> _activeCodeMock;
    private Mock<IUserService> _userMock;
    private EmailActiveCodeFluentValidation _validator;

    [SetUp]
    public void SetUp()
    {
        _userMock = new Mock<IUserService>();
        _activeCodeMock = new Mock<IActiveCodeService>();
        _validator = new EmailActiveCodeFluentValidation(_activeCodeMock.Object, _userMock.Object);
    }

    [Test]
    public void Validate_EmailExistsAndCodeNotExists_NoValidationErrorsHappen()
    {
        _userMock.Setup(m => m.IsInactiveUserExists(It.IsAny<string>())).Returns(true);
        _activeCodeMock.Setup(m => m.IsActiveCodeExists(It.IsAny<string>())).Returns(false);

        var result = _validator.TestValidate(new EmailActiveCodeDTO());

        result.ShouldNotHaveAnyValidationErrors();
    }


    [Test]
    public void Validate_EmailNotExists_ValidationErrorForEmailOnly()
    {
        _userMock.Setup(m => m.IsInactiveUserExists(It.IsAny<string>())).Returns(false);

        var result = _validator.TestValidate(new EmailActiveCodeDTO());

        result.ShouldHaveValidationErrorFor(m => m.Email);
    }


    [Test]
    public void Validate_EmailExistsAndCodeExists_ValidationErrorForEmailOnly()
    {
        _userMock.Setup(m => m.IsInactiveUserExists(It.IsAny<string>())).Returns(true);
        _activeCodeMock.Setup(m => m.IsActiveCodeExists(It.IsAny<string>())).Returns(true);

        var result = _validator.TestValidate(new EmailActiveCodeDTO());

        result.ShouldHaveValidationErrorFor(m => m.Email);
    }


}
