using System.Collections.Generic;
using System.Linq;
using BazaarOnline.Application.DTOs.AuthDTOs;
using BazaarOnline.Application.DTOs.Users.UserDTOs;
using BazaarOnline.Application.Securities;
using BazaarOnline.Application.Services.Users;
using BazaarOnline.Domain.Entities.Users;
using BazaarOnline.Domain.Interfaces;
using BazaarOnline.Infra.Data.Seeds.DefaultDatas;
using Moq;
using NUnit.Framework;

namespace BazaarOnline.Application.UnitTests.Services.Users;

[TestFixture]
public class UserServiceTests
{
    private Mock<IRepository> _repositoryMock;
    private UserService _userService;

    [SetUp]
    public void SetUp()
    {
        _repositoryMock = new Mock<IRepository>();
        _userService = new UserService(_repositoryMock.Object);
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

        _repositoryMock.Verify(m => m.Update<User>(user));
        _repositoryMock.Verify(m => m.Save());
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
        _repositoryMock.Setup(m => m.GetAll<User>()).Returns(new List<User>().AsQueryable());

        var result = _userService.ComparePassword("a@b.c", "password");

        Assert.IsFalse(result);
    }

    [Test]
    public void ComparePasswordEmail_UserFoundPasswordCorrect_ReturnTrue()
    {
        var password = "pa$$word";

        _repositoryMock.Setup(m => m.GetAll<User>()).Returns(new List<User>{
            new User {Email="a@b.c", Password = PasswordHelper.HashPassword(password) },
        }.AsQueryable());

        var result = _userService.ComparePassword("a@b.c", password);

        Assert.IsTrue(result);
    }

    [Test]
    public void ComparePasswordEmail_UserFoundPasswordInCorrect_ReturnFalse()
    {
        var password = "pa$$word";

        _repositoryMock.Setup(m => m.GetAll<User>()).Returns(new List<User>{
            new User {Email="a@b.c", Password = PasswordHelper.HashPassword(password) },
        }.AsQueryable());

        var result = _userService.ComparePassword("a@b.c", "incorrect password");

        Assert.IsFalse(result);
    }

    [Test]
    public void CreateUser_UserDTO_CallAddAndSave()
    {
        _userService.CreateUser(new UserCreateDTO { Password = "a", Email = "" });

        _repositoryMock.Verify(m => m.Add<User>(It.IsAny<User>()));
        _repositoryMock.Verify(m => m.Save());
    }

    [Test]
    public void CreateUser_UserDTO_AddsNormalUserRole()
    {
        var user = _userService.CreateUser(new UserCreateDTO { Password = "a", Email = "" });

        Assert.IsNotNull(user.UserRoles.Find(ur => ur.RoleId == DefaultRoles.NormalUser.Id));
    }

    [Test]
    public void CreateUser_UserDTO_AddsExpectedRoles()
    {
        var user = _userService.CreateUser(new UserCreateDTO
        {
            Password = "a",
            Email = "",
            Roles = new List<int> { 1 }
        });

        Assert.IsNotNull(user.UserRoles.Find(ur => ur.RoleId == 1));
    }

    [Test]
    public void CreateUser_UserDTO_AddsDuplicateRolesOnce()
    {
        var user = _userService.CreateUser(new UserCreateDTO
        {
            Password = "a",
            Email = "",
            Roles = new List<int> { 1, 1 }
        });

        var result = user.UserRoles.Where(ur => ur.RoleId == 1).Count();

        Assert.That(result, Is.EqualTo(1));
    }

    [Test]
    public void CreateUser_RegisterDTO_AddsNormalUserRole()
    {
        var user = _userService.CreateUser(new UserRegisterDTO { Password = "a", Email = "" });

        Assert.IsNotNull(user.UserRoles.Find(ur => ur.RoleId == DefaultRoles.NormalUser.Id));
    }

    [Test]
    public void CreateUser_RegirsterDTO_CallAddAndSave()
    {
        _userService.CreateUser(new UserRegisterDTO { Password = "a", Email = "" });

        _repositoryMock.Verify(m => m.Add<User>(It.IsAny<User>()));
        _repositoryMock.Verify(m => m.Save());
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
        _repositoryMock.Setup(m => m.GetAll<User>()).Returns(new List<User>().AsQueryable());

        var result = _userService.FindUser("a@b.c");

        Assert.IsNull(result);
    }

    [Test]
    public void FindUserEmail_UserFound_ReturnUserObject()
    {
        _repositoryMock.Setup(m => m.GetAll<User>()).Returns(new List<User>{
            new User {Email="a@b.c"},
        }.AsQueryable());

        var result = _userService.FindUser("a@b.c");

        Assert.That(result, Is.TypeOf<User>());
    }

    [Test]
    public void IsEmailExists_EmailNotFound_ReturnFalse()
    {
        _repositoryMock.Setup(m => m.GetAll<User>()).Returns(new List<User>().AsQueryable());

        var result = _userService.IsEmailExists("a@b.c");

        Assert.IsFalse(result);
    }

    [Test]
    public void IsEmailExists_EmailFound_ReturnTrue()
    {
        _repositoryMock.Setup(m => m.GetAll<User>()).Returns(new List<User>{
            new User {Email="a@b.c"},
        }.AsQueryable());

        var result = _userService.IsEmailExists("a@b.c");

        Assert.IsTrue(result);
    }

    [Test]
    public void IsPhoneNumberExists_PhoneNotFound_ReturnFalse()
    {
        _repositoryMock.Setup(m => m.GetAll<User>()).Returns(new List<User>().AsQueryable());

        var result = _userService.IsPhoneNumberExists("a@b.c");

        Assert.IsFalse(result);
    }

    [Test]
    public void IsPhoneNumberExists_PhoneFound_ReturnTrue()
    {
        _repositoryMock.Setup(m => m.GetAll<User>()).Returns(new List<User>{
            new User {PhoneNumber="0"},
        }.AsQueryable());

        var result = _userService.IsPhoneNumberExists("0");

        Assert.IsTrue(result);
    }

    [Test]
    public void IsInactiveUserExists_EmailNotFound_ReturnFalse()
    {
        _repositoryMock.Setup(m => m.GetAll<User>()).Returns(new List<User>().AsQueryable());

        var result = _userService.IsInactiveUserExists("a@b.c");

        Assert.IsFalse(result);
    }

    [Test]
    public void IsInactiveUserExists_EmailFoundUserIsActive_ReturnFalse()
    {
        _repositoryMock.Setup(m => m.GetAll<User>()).Returns(new List<User>{
            new User {Email="a@b.c", IsActive=true},
        }.AsQueryable());

        var result = _userService.IsInactiveUserExists("a@b.c");

        Assert.IsFalse(result);
    }

    [Test]
    public void IsInactiveUserExists_EmailFoundUserIsNotActive_ReturnTrue()
    {
        _repositoryMock.Setup(m => m.GetAll<User>()).Returns(new List<User>{
            new User {Email="a@b.c", IsActive=false},
        }.AsQueryable());

        var result = _userService.IsInactiveUserExists("a@b.c");

        Assert.IsTrue(result);
    }

    [Test]
    public void SoftDeleteUser_WhenCalled_CallSaveAndUpdate()
    {
        User user = new User();

        _userService.SoftDeleteUser(user);

        _repositoryMock.Verify(m => m.Update(user));
        _repositoryMock.Verify(m => m.Save());
    }

    [Test]
    public void UpdateUser_WhenCalled_CallUpdateAndSave()
    {
        User user = new User();

        _userService.UpdateUser(user, new UserUpdateDTO());

        _repositoryMock.Verify(m => m.Update<User>(user));
        _repositoryMock.Verify(m => m.Save());
    }


    [Test]
    public void UpdateUserRoles_WhenCalled_CallAddUserRoleRange()
    {
        User user = new User { Id = 1 };

        _userService.UpdateUserRoles(user,
            new UserUpdateRoleDTO { Roles = new List<int>() });

        _repositoryMock.Verify(m => m.AddRange<UserRole>(It.IsAny<IEnumerable<UserRole>>()));
    }

    [Test]
    public void UpdateUserRoles_WhenCalled_CallDeleteUserRoleRange()
    {
        User user = new User { Id = 1 };

        _userService.UpdateUserRoles(user,
            new UserUpdateRoleDTO { Roles = new List<int>() });

        _repositoryMock.Verify(m => m.RemoveRange<UserRole>(It.IsAny<IEnumerable<UserRole>>()));
    }

    [Test]
    public void UpdateUserRoles_WhenCalled_CallSave()
    {
        User user = new User { Id = 1 };

        _userService.UpdateUserRoles(user,
            new UserUpdateRoleDTO { Roles = new List<int>() });

        _repositoryMock.Verify(m => m.Save());
    }


}
