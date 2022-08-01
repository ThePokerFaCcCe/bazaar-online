using BazaarOnline.Application.DTOs.AuthDTOs;
using BazaarOnline.Application.FluentValidations.Auth;
using BazaarOnline.Application.Interfaces.Users;
using FluentValidation.TestHelper;
using Moq;
using NUnit.Framework;
namespace BazaarOnline.Application.UnitTests.FluentValidations.Auth;

[TestFixture]
public class ActivateUserEmailFluentValidationTests
{
    private Mock<IActiveCodeService> _activeCodeMock;
    private Mock<IUserService> _userMock;
    private ActivateUserEmailFluentValidation _validator;

    [SetUp]
    public void SetUp()
    {
        _userMock = new Mock<IUserService>();
        _activeCodeMock = new Mock<IActiveCodeService>();
        _validator = new ActivateUserEmailFluentValidation(_userMock.Object, _activeCodeMock.Object);
    }

    [Test]
    public void Validate_EmailAndCodeExists_NoValidationErrorsHappen()
    {
        _userMock.Setup(m => m.IsInactiveUserExists(It.IsAny<string>())).Returns(true);
        _activeCodeMock.Setup(m => m.IsActiveCodeExists(It.IsAny<string>(), It.IsAny<string>())).Returns(true);

        var result = _validator.TestValidate(new ActivateUserEmailDTO());

        result.ShouldNotHaveAnyValidationErrors();
    }

    [Test]
    public void Validate_EmailExistsAndCodeNotExists_ValidationErrorForCodeOnly()
    {
        _userMock.Setup(m => m.IsInactiveUserExists(It.IsAny<string>())).Returns(true);
        _activeCodeMock.Setup(m => m.IsActiveCodeExists(It.IsAny<string>(), It.IsAny<string>())).Returns(false);

        var result = _validator.TestValidate(new ActivateUserEmailDTO());

        result.ShouldHaveValidationErrorFor((m => m.Code)).Only();
    }

    [Test]
    public void Validate_EmailNotExists_ValidationErrorForEmailOnly()
    {
        _userMock.Setup(m => m.IsInactiveUserExists(It.IsAny<string>())).Returns(false);
        _activeCodeMock.Setup(m => m.IsActiveCodeExists(It.IsAny<string>(), It.IsAny<string>())).Returns(false);

        var result = _validator.TestValidate(new ActivateUserEmailDTO());

        result.ShouldHaveValidationErrorFor((m => m.Email)).Only();
    }

}
