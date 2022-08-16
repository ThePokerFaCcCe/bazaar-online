using System.Collections.Generic;
using System.Linq;
using BazaarOnline.Application.DTOs.Users.UserDashboardDTOs;
using BazaarOnline.Application.Services.Users;
using BazaarOnline.Application.ViewModels.Users.UserDashboardViewModels;
using BazaarOnline.Domain.Entities.Users;
using BazaarOnline.Domain.Interfaces;
using Moq;
using NUnit.Framework;

namespace BazaarOnline.Application.UnitTests.Services.Users;

[TestFixture]
public class UserDashboardTests
{
    private Mock<IRepository> _repositoryMock;
    private UserDashboardService _userDashboardService;

    [SetUp]
    public void SetUp()
    {
        _repositoryMock = new Mock<IRepository>();
        _userDashboardService = new UserDashboardService(_repositoryMock.Object);
    }

    [Test]
    public void GetUserDashboardDetail_UserIdExists_ReturnUserDashboardDetailViewModel()
    {
        _repositoryMock.Setup(m => m.Get<User>(1)).Returns(new User());

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

        _repositoryMock.Verify(m => m.Update<User>(It.IsAny<User>()));
        _repositoryMock.Verify(m => m.Save());
    }

    [Test]
    public void IsEmailExists_PhoneNumberNotFound_ReturnFalse()
    {
        _repositoryMock.Setup(m => m.GetAll<User>()).Returns(new List<User>().AsQueryable());

        var result = _userDashboardService.IsPhoneNumberExists("00");

        Assert.IsFalse(result);
    }

    [Test]
    public void IsPhoneNumberExists_PhoneNumberFound_ReturnTrue()
    {
        _repositoryMock.Setup(m => m.GetAll<User>()).Returns(new List<User>{
            new User {PhoneNumber="00"},
        }.AsQueryable());

        var result = _userDashboardService.IsPhoneNumberExists("00");

        Assert.IsTrue(result);
    }
}
