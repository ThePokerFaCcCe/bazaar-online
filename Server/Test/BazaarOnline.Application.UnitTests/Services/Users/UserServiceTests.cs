using System.Collections.Generic;
using System.Linq;
using BazaarOnline.Application.DTOs.AuthDTOs;
using BazaarOnline.Application.DTOs.Users.UserDTOs;
using BazaarOnline.Application.Securities;
using BazaarOnline.Application.Services.Users;
using BazaarOnline.Domain.Entities.Users;
using BazaarOnline.Domain.Interfaces.Users;
using Moq;
using NUnit.Framework;

namespace BazaarOnline.Application.UnitTests.Services.Users;

[TestFixture]
public class UserServiceTests
{
    private Mock<IUserRepository> _userRepositoryMock;
    private UserService _userService;

    [SetUp]
    public void SetUp()
    {
        _userRepositoryMock = new Mock<IUserRepository>();
        _userService = new UserService(_userRepositoryMock.Object);
    }

    [Test]
    public void ActivateUser_WhenCalled_SetUserIsActiveTrue()
    {
        var user = new User { IsActive = false };

        _userService.ActivateUser(user);

        Assert.IsTrue(user.IsActive);
    }

    [Test]
    public void ActivateUser_WhenCalled_CallUpdateAndSave()
    {
        var user = new User { IsActive = false };

        _userService.ActivateUser(user);

        _userRepositoryMock.Verify(m => m.UpdateUser(user));
        _userRepositoryMock.Verify(m => m.Save());
    }

    [Test]
    public void ComparePasswordUser_CorrectPassword_ReturnTrue()
    {
        var password = "pa$$word";
        var user = new User { Password = PasswordHelper.HashPassword(password) };

        var result = _userService.ComparePassword(user, password);

        Assert.IsTrue(result);
    }

    [Test]
    public void ComparePasswordUser_InCorrectPassword_ReturnFalse()
    {
        var password = "pa$$word";
        var user = new User { Password = PasswordHelper.HashPassword(password) };

        var result = _userService.ComparePassword(user, "incorrect password");

        Assert.IsFalse(result);
    }

    [Test]
    public void ComparePasswordEmail_UserNotFound_ReturnFalse()
    {
        _userRepositoryMock.Setup(m => m.GetUsers()).Returns(new List<User>().AsQueryable());

        var result = _userService.ComparePassword("a@b.c", "password");

        Assert.IsFalse(result);
    }

    [Test]
    public void ComparePasswordEmail_UserFoundPasswordCorrect_ReturnTrue()
    {
        var password = "pa$$word";

        _userRepositoryMock.Setup(m => m.GetUsers()).Returns(new List<User>{
            new User {Email="a@b.c", Password = PasswordHelper.HashPassword(password) },
        }.AsQueryable());

        var result = _userService.ComparePassword("a@b.c", password);

        Assert.IsTrue(result);
    }

    [Test]
    public void ComparePasswordEmail_UserFoundPasswordInCorrect_ReturnFalse()
    {
        var password = "pa$$word";

        _userRepositoryMock.Setup(m => m.GetUsers()).Returns(new List<User>{
            new User {Email="a@b.c", Password = PasswordHelper.HashPassword(password) },
        }.AsQueryable());

        var result = _userService.ComparePassword("a@b.c", "incorrect password");

        Assert.IsFalse(result);
    }

    [Test]
    public void CreateUser_UserDTO_CallAddAndSave()
    {
        _userService.CreateUser(new UserCreateDTO { Password = "a", Email = "" });

        _userRepositoryMock.Verify(m => m.AddUser(It.IsAny<User>()));
        _userRepositoryMock.Verify(m => m.Save());
    }

    [Test]
    public void CreateUser_RegirsterDTO_CallAddAndSave()
    {
        _userService.CreateUser(new UserRegisterDTO { Password = "a", Email = "" });

        _userRepositoryMock.Verify(m => m.AddUser(It.IsAny<User>()));
        _userRepositoryMock.Verify(m => m.Save());
    }

    [Test]
    public void CreateUser_RegirsterDTO_CreatedUserIsNotActive()
    {
        var result = _userService.CreateUser(new UserRegisterDTO { Password = "a", Email = "" });

        Assert.IsFalse(result.IsActive);
    }

    [Test]
    public void FindUserEmail_UserNotFound_ReturnNull()
    {
        _userRepositoryMock.Setup(m => m.GetUsers()).Returns(new List<User>().AsQueryable());

        var result = _userService.FindUser("a@b.c");

        Assert.IsNull(result);
    }

    [Test]
    public void FindUserEmail_UserFound_ReturnUserObject()
    {
        _userRepositoryMock.Setup(m => m.GetUsers()).Returns(new List<User>{
            new User {Email="a@b.c"},
        }.AsQueryable());

        var result = _userService.FindUser("a@b.c");

        Assert.That(result, Is.TypeOf<User>());
    }

    [Test]
    public void IsEmailExists_EmailNotFound_ReturnFalse()
    {
        _userRepositoryMock.Setup(m => m.GetUsers()).Returns(new List<User>().AsQueryable());

        var result = _userService.IsEmailExists("a@b.c");

        Assert.IsFalse(result);
    }

    [Test]
    public void IsEmailExists_EmailFound_ReturnTrue()
    {
        _userRepositoryMock.Setup(m => m.GetUsers()).Returns(new List<User>{
            new User {Email="a@b.c"},
        }.AsQueryable());

        var result = _userService.IsEmailExists("a@b.c");

        Assert.IsTrue(result);
    }

    [Test]
    public void IsPhoneNumberExists_PhoneNotFound_ReturnFalse()
    {
        _userRepositoryMock.Setup(m => m.GetUsers()).Returns(new List<User>().AsQueryable());

        var result = _userService.IsPhoneNumberExists("a@b.c");

        Assert.IsFalse(result);
    }

    [Test]
    public void IsPhoneNumberExists_PhoneFound_ReturnTrue()
    {
        _userRepositoryMock.Setup(m => m.GetUsers()).Returns(new List<User>{
            new User {PhoneNumber="0"},
        }.AsQueryable());

        var result = _userService.IsPhoneNumberExists("0");

        Assert.IsTrue(result);
    }

    [Test]
    public void IsInactiveUserExists_EmailNotFound_ReturnFalse()
    {
        _userRepositoryMock.Setup(m => m.GetUsers()).Returns(new List<User>().AsQueryable());

        var result = _userService.IsInactiveUserExists("a@b.c");

        Assert.IsFalse(result);
    }

    [Test]
    public void IsInactiveUserExists_EmailFoundUserIsActive_ReturnFalse()
    {
        _userRepositoryMock.Setup(m => m.GetUsers()).Returns(new List<User>{
            new User {Email="a@b.c", IsActive=true},
        }.AsQueryable());

        var result = _userService.IsInactiveUserExists("a@b.c");

        Assert.IsFalse(result);
    }

    [Test]
    public void IsInactiveUserExists_EmailFoundUserIsNotActive_ReturnTrue()
    {
        _userRepositoryMock.Setup(m => m.GetUsers()).Returns(new List<User>{
            new User {Email="a@b.c", IsActive=false},
        }.AsQueryable());

        var result = _userService.IsInactiveUserExists("a@b.c");

        Assert.IsTrue(result);
    }

    [Test]
    public void SoftDeleteUser_WhenCalled_CallSaveAndSoftDelete()
    {
        User user = new User();

        _userService.SoftDeleteUser(user);

        _userRepositoryMock.Verify(m => m.SoftDeleteUser(user));
        _userRepositoryMock.Verify(m => m.Save());
    }

    [Test]
    public void UpdateUser_WhenCalled_CallUpdateAndSave()
    {
        User user = new User();

        _userService.UpdateUser(user, new UserUpdateDTO());

        _userRepositoryMock.Verify(m => m.UpdateUser(user));
        _userRepositoryMock.Verify(m => m.Save());
    }


}
