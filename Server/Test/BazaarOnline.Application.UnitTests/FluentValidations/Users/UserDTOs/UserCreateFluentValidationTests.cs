using System.Collections.Generic;
using BazaarOnline.Application.DTOs.Users.UserDTOs;
using BazaarOnline.Application.FluentValidations;
using BazaarOnline.Application.Interfaces.Permissions;
using BazaarOnline.Application.Interfaces.Users;
using FluentValidation.TestHelper;
using Moq;
using NUnit.Framework;
namespace BazaarOnline.Application.UnitTests.FluentValidations.Auth;

[TestFixture]
public class UserCreateFluentValidationTests
{
    private Mock<IUserService> _userMock;
    private Mock<IRoleService> _roleServiceMock;
    private UserCreateFluentValidation _validator;

    [SetUp]
    public void SetUp()
    {
        _userMock = new Mock<IUserService>();
        _roleServiceMock = new Mock<IRoleService>();
        _validator = new UserCreateFluentValidation(_userMock.Object, _roleServiceMock.Object);

        _roleServiceMock.Setup(m => m.GetRoleIds()).Returns(new List<int>());
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


    [Test]
    public void Validate_HasInvalidPerms_ValidationErrorForPermission()
    {

        var result = _validator.TestValidate(new UserCreateDTO
        {
            Roles = new List<int> { 1, 2, 999 }
        });

        result.ShouldHaveValidationErrorFor(m => m.Roles);
    }

    [Test]
    public void Validate_HasValidPerms_NoValidationErrorsHappen()
    {
        _roleServiceMock.Setup(m => m.GetRoleIds()).Returns(new List<int> { 1, 2 });
        var result = _validator.TestValidate(new UserCreateDTO
        {
            Roles = new List<int> { 1 }
        });

        result.ShouldNotHaveAnyValidationErrors();
    }


}
