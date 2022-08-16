using System.Collections.Generic;
using System.Linq;
using BazaarOnline.Application.Services.Permissions;
using BazaarOnline.Domain.Entities.Permissions;
using BazaarOnline.Domain.Entities.Users;
using BazaarOnline.Domain.Interfaces;
using Moq;
using NUnit.Framework;

namespace BazaarOnline.Application.UnitTests.Services.Permissions;

[TestFixture]
public class PermissionServiceTests
{

    private Mock<IRepository> _repositoryMock;
    private PermissionService _permissionService;

    [SetUp]
    public void SetUp()
    {
        _repositoryMock = new Mock<IRepository>();
        _permissionService = new PermissionService(_repositoryMock.Object);
    }

    [Test]
    public void HasUserPermission_HasPerm_ReturnTrue()
    {
        _repositoryMock.Setup(m => m.GetAll<UserRole>())
            .Returns(new List<UserRole>{
                new UserRole{
                    UserId=1,
                    RoleId=2,
                }
            }.AsQueryable());

        _repositoryMock.Setup(m => m.GetAll<RolePermission>())
            .Returns(new List<RolePermission>{
                new RolePermission{
                    RoleId=2,
                    PermissionId=3,
                }
            }.AsQueryable());

        var result = _permissionService.HasUserPermission(userId: 1, permissionId: 3);

        Assert.IsTrue(result);
    }

    [Test]
    public void HasUserPermission_HasNotPerm_ReturnFalse()
    {
        _repositoryMock.Setup(m => m.GetAll<UserRole>())
            .Returns(new List<UserRole>().AsQueryable());

        var result = _permissionService.HasUserPermission(userId: 1, permissionId: 3);

        Assert.IsFalse(result);
    }

}
