using System.Collections.Generic;
using System.Linq;
using BazaarOnline.Application.DTOs.Permissions.RoleDTOs;
using BazaarOnline.Application.DTOs.Users.UserDTOs;
using BazaarOnline.Application.Services.Permissions;
using BazaarOnline.Application.ViewModels.RoleViewModels;
using BazaarOnline.Domain.Entities.Permissions;
using BazaarOnline.Domain.Entities.Users;
using BazaarOnline.Domain.Interfaces.Permissions;
using BazaarOnline.Infra.Data.Seeds.DefaultDatas;
using Moq;
using NUnit.Framework;

namespace BazaarOnline.Application.UnitTests.Services.Permissions;

[TestFixture]
public class RoleServiceTests
{

    private Mock<IRoleRepository> _roleRepositoryMock;
    private RoleService _roleService;

    [SetUp]
    public void SetUp()
    {
        _roleRepositoryMock = new Mock<IRoleRepository>();
        _roleService = new RoleService(_roleRepositoryMock.Object);

    }

    [Test]
    public void CreateRole_WhenCalled_CallAddRole()
    {
        _roleRepositoryMock.Setup(m => m.AddRole(It.IsAny<Role>())).Returns(new Role());

        _roleService.CreateRole(new RoleCreateDTO { Permissions = new List<int>() });

        _roleRepositoryMock.Verify(m => m.AddRole(It.IsAny<Role>()));
    }

    [Test]
    public void CreateRole_WhenCalled_CallSave()
    {
        _roleRepositoryMock.Setup(m => m.AddRole(It.IsAny<Role>())).Returns(new Role());

        _roleService.CreateRole(new RoleCreateDTO { Permissions = new List<int>() });

        _roleRepositoryMock.Verify(m => m.Save());
    }

    [Test]
    public void DeleteRole_WhenCalled_CallDeleteRole()
    {
        _roleService.DeleteRole(new Role());

        _roleRepositoryMock.Verify(m => m.DeleteRole(It.IsAny<Role>()));
    }

    [Test]
    public void DeleteRole_WhenCalled_CallSave()
    {
        _roleService.DeleteRole(new Role());

        _roleRepositoryMock.Verify(m => m.Save());
    }

    [Test]
    public void FindRole_RoleExists_ReturnRole()
    {
        _roleRepositoryMock.Setup(m => m.GetRoles()).Returns(new List<Role>(){
            new Role{Id=1},
        }.AsQueryable());

        var result = _roleService.FindRole(1);

        Assert.That(result, Is.TypeOf<Role>());
    }

    [Test]
    public void FindRole_RoleNotExists_ReturnNull()
    {
        _roleRepositoryMock.Setup(m => m.GetRoles()).Returns(new List<Role>(){
            new Role{Id=1},
        }.AsQueryable());

        var result = _roleService.FindRole(2);

        Assert.That(result, Is.Null);
    }


    [Test]
    public void GetRoleDetail_RoleExists_ReturnRoleDetailViewModel()
    {
        _roleRepositoryMock.Setup(m => m.GetRoles()).Returns(new List<Role>(){
            new Role{Id=1,RolePermissions=new List<RolePermission>()},
        }.AsQueryable());

        var result = _roleService.GetRoleDetail(1);

        Assert.That(result, Is.TypeOf<RoleDetailViewModel>());
    }

    [Test]
    public void GetRoleDetail_RoleNotExists_ReturnNull()
    {
        _roleRepositoryMock.Setup(m => m.GetRoles()).Returns(new List<Role>(){
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

        _roleRepositoryMock.Verify(m => m.AddRolePermissionRange(It.IsAny<List<int>>(), 1));
    }

    [Test]
    public void UpdateRole_WhenCalled_CallDeleteRolePermissionRange()
    {
        _roleService.UpdateRole(
            new Role { Id = 1, RolePermissions = new List<RolePermission>() },
            new RoleUpdateDTO { Title = string.Empty, Permissions = new List<int>() });

        _roleRepositoryMock.Verify(m => m.DeleteRolePermissionRange(It.IsAny<List<int>>(), 1));
    }

    [Test]
    public void UpdateRole_WhenCalled_CallUpdateRole()
    {
        _roleService.UpdateRole(
            new Role { Id = 1, RolePermissions = new List<RolePermission>() },
            new RoleUpdateDTO { Title = string.Empty, Permissions = new List<int>() });

        _roleRepositoryMock.Verify(m => m.UpdateRole(It.IsAny<Role>()));
    }

    [Test]
    public void UpdateRole_WhenCalled_CallSave()
    {
        _roleService.UpdateRole(
            new Role { Id = 1, RolePermissions = new List<RolePermission>() },
            new RoleUpdateDTO { Title = string.Empty, Permissions = new List<int>() });

        _roleRepositoryMock.Verify(m => m.Save());
    }


    [Test]
    public void UpdateUserRoles_WhenCalled_CallAddUserRoleRange()
    {
        _roleService.UpdateUserRoles(new User { Id = 1 },
            new UserUpdateRoleDTO { Roles = new List<int>() });

        _roleRepositoryMock.Verify(m => m.AddUserRoleRange(It.IsAny<List<int>>(), 1));
    }

    [Test]
    public void UpdateUserRoles_WhenCalled_CallDeleteUserRoleRange()
    {
        _roleService.UpdateUserRoles(new User { Id = 1 },
            new UserUpdateRoleDTO { Roles = new List<int>() });

        _roleRepositoryMock.Verify(m => m.DeleteUserRoleRange(It.IsAny<List<int>>(), 1));
    }

    [Test]
    public void UpdateUserRoles_WhenCalled_CallSave()
    {
        _roleService.UpdateUserRoles(new User { Id = 1 },
            new UserUpdateRoleDTO { Roles = new List<int>() });

        _roleRepositoryMock.Verify(m => m.Save());
    }
}
