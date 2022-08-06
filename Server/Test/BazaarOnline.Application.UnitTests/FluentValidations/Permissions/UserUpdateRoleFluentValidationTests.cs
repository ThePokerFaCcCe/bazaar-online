using System.Collections.Generic;
using BazaarOnline.Application.DTOs.Users.UserDTOs;
using BazaarOnline.Application.FluentValidations;
using BazaarOnline.Application.Interfaces.Permissions;
using FluentValidation.TestHelper;
using Moq;
using NUnit.Framework;

namespace BazaarOnline.Application.UnitTests.FluentValidations.Permissions;

[TestFixture]
public class UserUpdateRoleFluentValidationTests
{
    private Mock<IRoleService> _roleServiceMock;
    private UserUpdateRoleFluentValidation _validator;

    [SetUp]
    public void SetUp()
    {
        _roleServiceMock = new Mock<IRoleService>();
        _validator = new UserUpdateRoleFluentValidation(_roleServiceMock.Object);
    }

    [Test]
    public void Validate_HasInvalidPerms_ValidationErrorForPermission()
    {
        _roleServiceMock.Setup(m => m.GetRoleIds()).Returns(new List<int> { 1, 2 });

        var result = _validator.TestValidate(new UserUpdateRoleDTO
        {
            Roles = new List<int> { 1, 2, 3 }
        });

        result.ShouldHaveValidationErrorFor(m => m.Roles);
    }

    [Test]
    public void Validate_HasValidPerms_NoValidationErrorsHappen()
    {
        _roleServiceMock.Setup(m => m.GetRoleIds()).Returns(new List<int> { 1, 2 });

        var result = _validator.TestValidate(new UserUpdateRoleDTO
        {
            Roles = new List<int> { 1 }
        });

        result.ShouldNotHaveAnyValidationErrors();
    }

}
