using System.Collections.Generic;
using System.Linq;
using BazaarOnline.Application.DTOs.Users.UserDashboardDTOs;
using BazaarOnline.Application.Services.Users;
using BazaarOnline.Application.ViewModels.Users.UserDashboardViewModels;
using BazaarOnline.Domain.Entities.Users;
using BazaarOnline.Domain.Interfaces.Users;
using Moq;
using NUnit.Framework;

namespace BazaarOnline.Application.UnitTests.Services.Users;

[TestFixture]
public class UserDashboardTests
{
    private Mock<IUserRepository> _userRepositoryMock;
    private UserDashboardService _userDashboardService;

    [SetUp]
    public void SetUp()
    {
        _userRepositoryMock = new Mock<IUserRepository>();
        _userDashboardService = new UserDashboardService(_userRepositoryMock.Object);
    }

    [Test]
    public void GetUserDashboardDetail_UserIdExists_ReturnUserDashboardDetailViewModel()
    {
        _userRepositoryMock.Setup(m => m.FindUser(1)).Returns(new User());

        var result = _userDashboardService.GetUserDashboardDetail(1);

        Assert.That(result, Is.TypeOf<UserDashboardDetailViewModel>());
    }

    [Test]
    public void GetUserDashboardDetail_UserIdNotExists_ReturnNull()
    {
        var result = _userDashboardService.GetUserDashboardDetail(1);

        Assert.That(result, Is.Null);
    }

    [Test]
    public void UpdateUser_WhenCalled_UpdatesUserModel()
    {
        var user = new User { FirstName = "a" };
        var updateDTO = new UserDashboardUpdateDTO { FirstName = "b" };

        _userDashboardService.UpdateUser(user, updateDTO);

        Assert.That(user.FirstName, Is.EqualTo(updateDTO.FirstName));
    }

    [Test]
    public void UpdateUser_WhenCalled_CallUpdateAndSave()
    {
        _userDashboardService.UpdateUser(new User(), new UserDashboardUpdateDTO());

        _userRepositoryMock.Verify(m => m.UpdateUser(It.IsAny<User>()));
        _userRepositoryMock.Verify(m => m.Save());
    }

    [Test]
    public void IsEmailExists_PhoneNumberNotFound_ReturnFalse()
    {
        _userRepositoryMock.Setup(m => m.GetUsers()).Returns(new List<User>().AsQueryable());

        var result = _userDashboardService.IsPhoneNumberExists("00");

        Assert.IsFalse(result);
    }

    [Test]
    public void IsPhoneNumberExists_PhoneNumberFound_ReturnTrue()
    {
        _userRepositoryMock.Setup(m => m.GetUsers()).Returns(new List<User>{
            new User {PhoneNumber="00"},
        }.AsQueryable());

        var result = _userDashboardService.IsPhoneNumberExists("00");

        Assert.IsTrue(result);
    }
}
