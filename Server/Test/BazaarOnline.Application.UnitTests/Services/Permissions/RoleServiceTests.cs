using System.Collections.Generic;
using System.Linq;
using BazaarOnline.Application.DTOs.Permissions.RoleDTOs;
using BazaarOnline.Application.Services.Permissions;
using BazaarOnline.Application.ViewModels.RoleViewModels;
using BazaarOnline.Domain.Entities.Permissions;
using BazaarOnline.Domain.Interfaces;
using BazaarOnline.Infra.Data.Seeds.DefaultDatas;
using Moq;
using NUnit.Framework;

namespace BazaarOnline.Application.UnitTests.Services.Permissions;

[TestFixture]
public class RoleServiceTests
{

    private Mock<IRepository> _repositoryMock;
    private RoleService _roleService;

    [SetUp]
    public void SetUp()
    {
        _repositoryMock = new Mock<IRepository>();
        _roleService = new RoleService(_repositoryMock.Object);

    }

    [Test]
    public void CreateRole_WhenCalled_CallAddRole()
    {
        _repositoryMock.Setup(m => m.Add<Role>(It.IsAny<Role>())).Returns(new Role());

        _roleService.CreateRole(new RoleCreateDTO { Permissions = new List<int>() });

        _repositoryMock.Verify(m => m.Add<Role>(It.IsAny<Role>()));
    }

    [Test]
    public void CreateRole_WhenCalled_CallSave()
    {
        _repositoryMock.Setup(m => m.Add<Role>(It.IsAny<Role>())).Returns(new Role());

        _roleService.CreateRole(new RoleCreateDTO { Permissions = new List<int>() });

        _repositoryMock.Verify(m => m.Save());
    }

    [Test]
    public void DeleteRole_WhenCalled_CallDeleteRole()
    {
        _roleService.DeleteRole(new Role());

        _repositoryMock.Verify(m => m.Remove<Role>(It.IsAny<Role>()));
    }

    [Test]
    public void DeleteRole_WhenCalled_CallSave()
    {
        _roleService.DeleteRole(new Role());

        _repositoryMock.Verify(m => m.Save());
    }

    [Test]
    public void FindRole_RoleExists_ReturnRole()
    {
        _repositoryMock.Setup(m => m.GetAll<Role>()).Returns(new List<Role>(){
            new Role{Id=1},
        }.AsQueryable());

        var result = _roleService.FindRole(1);

        Assert.That(result, Is.TypeOf<Role>());
    }

    [Test]
    public void FindRole_RoleNotExists_ReturnNull()
    {
        _repositoryMock.Setup(m => m.GetAll<Role>()).Returns(new List<Role>(){
            new Role{Id=1},
        }.AsQueryable());

        var result = _roleService.FindRole(2);

        Assert.That(result, Is.Null);
    }


    [Test]
    public void GetRoleDetail_RoleExists_ReturnRoleDetailViewModel()
    {
        _repositoryMock.Setup(m => m.GetAll<Role>()).Returns(new List<Role>(){
            new Role{Id=1,RolePermissions=new List<RolePermission>()},
        }.AsQueryable());

        var result = _roleService.GetRoleDetail(1);

        Assert.That(result, Is.TypeOf<RoleDetailViewModel>());
    }

    [Test]
    public void GetRoleDetail_RoleNotExists_ReturnNull()
    {
        _repositoryMock.Setup(m => m.GetAll<Role>()).Returns(new List<Role>(){
            new Role{Id=1,RolePermissions=new List<RolePermission>()},
        }.AsQueryable());

        var result = _roleService.GetRoleDetail(2);

        Assert.That(result, Is.Null);
    }

    [Test]
    public void IsRoleUneditable_RoleIsUneditable_ReturnTrue()
    {
        var result = _roleService.IsRoleUneditable(DefaultRoles.UneditableRoles.First().Id);

        Assert.That(result, Is.True);
    }

    [Test]
    public void IsRoleUneditable_RoleIsNotUneditable_ReturnFals4()
    {
        var result = _roleService.IsRoleUneditable(0);

        Assert.That(result, Is.False);
    }

    [Test]
    public void UpdateRole_WhenCalled_CallAddRolePermissionRange()
    {
        _roleService.UpdateRole(
            new Role { Id = 1, RolePermissions = new List<RolePermission>() },
            new RoleUpdateDTO { Title = string.Empty, Permissions = new List<int>() });

        _repositoryMock.Verify(m => m.AddRange<RolePermission>(It.IsAny<IEnumerable<RolePermission>>()));
    }

    [Test]
    public void UpdateRole_WhenCalled_CallDeleteRolePermissionRange()
    {
        _roleService.UpdateRole(
            new Role { Id = 1, RolePermissions = new List<RolePermission>() },
            new RoleUpdateDTO { Title = string.Empty, Permissions = new List<int>() });

        _repositoryMock.Verify(m => m.RemoveRange<RolePermission>(It.IsAny<IEnumerable<RolePermission>>()));
    }

    [Test]
    public void UpdateRole_WhenCalled_CallUpdateRole()
    {
        _roleService.UpdateRole(
            new Role { Id = 1, RolePermissions = new List<RolePermission>() },
            new RoleUpdateDTO { Title = string.Empty, Permissions = new List<int>() });

        _repositoryMock.Verify(m => m.Update<Role>(It.IsAny<Role>()));
    }

    [Test]
    public void UpdateRole_WhenCalled_CallSave()
    {
        _roleService.UpdateRole(
            new Role { Id = 1, RolePermissions = new List<RolePermission>() },
            new RoleUpdateDTO { Title = string.Empty, Permissions = new List<int>() });

        _repositoryMock.Verify(m => m.Save());
    }
}
