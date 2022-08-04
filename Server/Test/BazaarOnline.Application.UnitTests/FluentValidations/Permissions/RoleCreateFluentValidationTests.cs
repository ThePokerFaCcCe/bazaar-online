using System.Collections.Generic;
using BazaarOnline.Application.DTOs.Permissions.RoleDTOs;
using BazaarOnline.Application.FluentValidations.Permissions;
using BazaarOnline.Application.Interfaces.Permissions;
using FluentValidation.TestHelper;
using Moq;
using NUnit.Framework;

namespace BazaarOnline.Application.UnitTests.FluentValidations.Permissions;

[TestFixture]
public class RoleCreateFluentValidationTests
{
    private Mock<IPermissionService> _permissionServiceMock;
    private RoleCreateFluentValidation _validator;

    [SetUp]
    public void SetUp()
    {
        _permissionServiceMock = new Mock<IPermissionService>();
        _validator = new RoleCreateFluentValidation(_permissionServiceMock.Object);
    }

    [Test]
    public void Validate_HasInvalidPerms_ValidationErrorForPermission()
    {
        _permissionServiceMock.Setup(m => m.GetPermissionIds()).Returns(new List<int> { 1, 2 });

        var result = _validator.TestValidate(new RoleCreateDTO
        {
            Permissions = new List<int> { 1, 2, 3 }
        });

        result.ShouldHaveValidationErrorFor(m => m.Permissions);
    }

    [Test]
    public void Validate_HasValidPerms_NoValidationErrorsHappen()
    {
        _permissionServiceMock.Setup(m => m.GetPermissionIds()).Returns(new List<int> { 1, 2 });

        var result = _validator.TestValidate(new RoleCreateDTO
        {
            Permissions = new List<int> { 1 }
        });

        result.ShouldNotHaveAnyValidationErrors();
    }

}
