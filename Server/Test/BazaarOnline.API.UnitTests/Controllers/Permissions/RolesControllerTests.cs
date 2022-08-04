using BazaarOnline.API.Controllers;
using BazaarOnline.Application.DTOs.Permissions.RoleDTOs;
using BazaarOnline.Application.Interfaces.Permissions;
using BazaarOnline.Application.ViewModels.RoleViewModels;
using BazaarOnline.Domain.Entities.Permissions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace BazaarOnline.API.UnitTests.Controllers.Permissions;

[TestFixture]
public class RolesControllerTests
{
    private Mock<ILogger<RolesController>> _loggerMock;
    private Mock<IRoleService> _roleServiceMock;
    private RolesController _controller;

    [SetUp]
    public void SetUp()
    {
        _loggerMock = new Mock<ILogger<RolesController>>();
        _roleServiceMock = new Mock<IRoleService>();
        _controller = new RolesController(_loggerMock.Object, _roleServiceMock.Object);
    }

    [Test]
    public void GetRoleById_RoleExists_ReturnOk()
    {
        _roleServiceMock.Setup(m => m.GetRoleDetail(1)).Returns(new RoleDetailViewModel());

        var result = _controller.GetRoleById(1);

        Assert.That(result.Result, Is.TypeOf<OkObjectResult>());
    }

    [Test]
    public void GetRoleById_RoleNotExists_ReturnNotFound()
    {
        _roleServiceMock.Setup(m => m.GetRoleDetail(1)).Returns(value: null);

        var result = _controller.GetRoleById(1);

        Assert.That(result.Result, Is.TypeOf<NotFoundResult>());
    }

    [Test]
    public void CreateRole_InvalidModel_ReturnBadRequest()
    {
        _controller.ModelState.AddModelError("error", "error");
        var result = _controller.CreateRole(new RoleCreateDTO()); ;

        Assert.That(result.Result, Is.TypeOf<BadRequestObjectResult>());
    }

    [Test]
    public void CreateRole_ValidModel_CreateTheRole()
    {
        _roleServiceMock.Setup(m => m.CreateRole(It.IsAny<RoleCreateDTO>())).Returns(1);

        _controller.CreateRole(new RoleCreateDTO()); ;

        _roleServiceMock.Verify(m => m.CreateRole(It.IsAny<RoleCreateDTO>()));
    }

    [Test]
    public void CreateRole_ValidModel_ReturnCreatedAtAction()
    {
        _roleServiceMock.Setup(m => m.CreateRole(It.IsAny<RoleCreateDTO>())).Returns(1);

        var result = _controller.CreateRole(new RoleCreateDTO()); ;

        Assert.That(result.Result, Is.TypeOf<CreatedAtActionResult>());
    }

    [Test]
    public void UpdateRole_InvalidModel_ReturnBadRequest()
    {
        _roleServiceMock.Setup(m => m.FindRole(1)).Returns(new Role());

        _controller.ModelState.AddModelError("error", "error");
        var result = _controller.UpdateRole(1, new RoleUpdateDTO());

        Assert.That(result, Is.TypeOf<BadRequestObjectResult>());
    }

    [Test]
    public void UpdateRole_NotFoundRole_ReturnNotFound()
    {
        _roleServiceMock.Setup(m => m.FindRole(1)).Returns(value: null);

        var result = _controller.UpdateRole(1, new RoleUpdateDTO());

        Assert.That(result, Is.TypeOf<NotFoundResult>());
    }


    [Test]
    public void UpdateRole_UneditableRole_ReturnBadRequest()
    {
        _roleServiceMock.Setup(m => m.FindRole(1)).Returns(value: null);
        _roleServiceMock.Setup(m => m.IsRoleUneditable(1)).Returns(true);

        var result = _controller.UpdateRole(1, new RoleUpdateDTO());

        Assert.That(result, Is.TypeOf<ObjectResult>());
    }

    [Test]
    public void UpdateRole_ValidModel_CallUpdateRole()
    {
        _roleServiceMock.Setup(m => m.FindRole(1)).Returns(new Role());

        _controller.UpdateRole(1, new RoleUpdateDTO());

        _roleServiceMock.Verify(m => m.UpdateRole(It.IsAny<Role>(), It.IsAny<RoleUpdateDTO>()));
    }

    [Test]
    public void UpdateRole_ValidModel_ReturnOk()
    {
        _roleServiceMock.Setup(m => m.FindRole(1)).Returns(new Role());

        var result = _controller.UpdateRole(1, new RoleUpdateDTO());

        Assert.That(result, Is.TypeOf<OkResult>());
    }






    [Test]
    public void DeleteRole_NotFoundRole_ReturnNotFound()
    {
        _roleServiceMock.Setup(m => m.FindRole(1)).Returns(value: null);

        var result = _controller.DeleteRole(1);

        Assert.That(result, Is.TypeOf<NotFoundResult>());
    }


    [Test]
    public void DeleteRole_UneditableRole_ReturnBadRequest()
    {
        _roleServiceMock.Setup(m => m.FindRole(1)).Returns(value: null);
        _roleServiceMock.Setup(m => m.IsRoleUneditable(1)).Returns(true);

        var result = _controller.DeleteRole(1);

        Assert.That(result, Is.TypeOf<ObjectResult>());
    }

    [Test]
    public void DeleteRole_ValidModel_CallDeleteRole()
    {
        _roleServiceMock.Setup(m => m.FindRole(1)).Returns(new Role());

        _controller.DeleteRole(1);

        _roleServiceMock.Verify(m => m.DeleteRole(It.IsAny<Role>()));
    }

    [Test]
    public void DeleteRole_ValidModel_ReturnNoContent()
    {
        _roleServiceMock.Setup(m => m.FindRole(1)).Returns(new Role());

        var result = _controller.DeleteRole(1);

        Assert.That(result, Is.TypeOf<NoContentResult>());
    }

}
