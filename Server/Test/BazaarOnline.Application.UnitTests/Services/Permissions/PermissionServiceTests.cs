using BazaarOnline.Application.Services.Permissions;
using BazaarOnline.Domain.Interfaces.Permissions;
using Moq;
using NUnit.Framework;

namespace BazaarOnline.Application.UnitTests.Services.Permissions;

[TestFixture]
public class PermissionServiceTests
{

    private Mock<IPermissionRepository> _permissionRepositoryMock;
    private PermissionService _permissionService;

    [SetUp]
    public void SetUp()
    {
        _permissionRepositoryMock = new Mock<IPermissionRepository>();
        _permissionService = new PermissionService(_permissionRepositoryMock.Object);
    }

    [Test]
    public void HasUserPermission_HasPerm_ReturnTrue()
    {
        _permissionRepositoryMock.Setup(m => m.HasUserPermission(1, 2)).Returns(true);

        var result = _permissionService.HasUserPermission(1, 2);

        Assert.IsTrue(result);
    }

    [Test]
    public void HasUserPermission_HasNotPerm_ReturnFalse()
    {
        _permissionRepositoryMock.Setup(m => m.HasUserPermission(1, 2)).Returns(false);

        var result = _permissionService.HasUserPermission(1, 2);

        Assert.IsFalse(result);
    }

}
