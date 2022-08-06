using BazaarOnline.API.Controllers.Users;
using BazaarOnline.Application.DTOs.PaginationDTO;
using BazaarOnline.Application.DTOs.Users.UserDTOs;
using BazaarOnline.Application.Interfaces.Users;
using BazaarOnline.Application.ViewModels.Users.UserViewModels;
using BazaarOnline.Domain.Entities.Users;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace BazaarOnline.API.UnitTests.Controllers.Users;

[TestFixture]
public class UsersControllerTests
{

    private Mock<IUserService> _userMock;
    private UsersController _controller;

    [SetUp]
    public void SetUp()
    {
        _userMock = new Mock<IUserService>();
        _controller = new UsersController(_userMock.Object);
    }

    [Test]
    public void GetUsersList_WhenCalled_CallGetUsersListDetails()
    {
        _controller.GetUsersList(new UserFilterDTO(), new PaginationFilterDTO());

        _userMock.Verify(m => m.GetUserListDetails(It.IsAny<UserFilterDTO>(), It.IsAny<PaginationFilterDTO>()));
    }

    [Test]
    public void GetUsersList_WhenCalled_ReturnOkPaginationResultOfUserDetailListViewModel()
    {
        var result = _controller.GetUsersList(new UserFilterDTO(), new PaginationFilterDTO());

        Assert.That(result, Is.TypeOf<ActionResult<PaginationResultDTO<UserListDetailViewModel>>>());
    }

    [Test]
    public void GetUserDetail_UserIdExists_ReturnOkUserDetailViewModel()
    {
        _userMock.Setup(m => m.GetUserDetail(1)).Returns(new UserDetailViewModel());

        var result = _controller.GetUserDetail(1);

        Assert.That(result.Result, Is.TypeOf<OkObjectResult>());
        Assert.That(result, Is.TypeOf<ActionResult<UserDetailViewModel>>());
    }


    [Test]
    public void GetUserDetail_UserIdNotExists_ReturnNotFound()
    {
        var result = _controller.GetUserDetail(1);

        Assert.That(result.Result, Is.TypeOf<NotFoundResult>());
    }


    [Test]
    public void FindUserDetail_EmailExists_ReturnOkUserDetailViewModel()
    {
        _userMock.Setup(m => m.GetUserDetail("aaa@body.com")).Returns(new UserDetailViewModel());

        var result = _controller.FindUserDetail("aaa@body.com");

        Assert.That(result.Result, Is.TypeOf<OkObjectResult>());
        Assert.That(result, Is.TypeOf<ActionResult<UserDetailViewModel>>());
    }


    [Test]
    public void FindUserDetail_BadEmail_ReturnNotFound()
    {
        var result = _controller.FindUserDetail("not valid email");

        Assert.That(result.Result, Is.TypeOf<NotFoundResult>());
    }

    [Test]
    public void FindUserDetail_EmailNotExists_ReturnNotFound()
    {
        var result = _controller.FindUserDetail("a2@b.c");

        Assert.That(result.Result, Is.TypeOf<NotFoundResult>());
    }

    [Test]
    public void CreateUser_InvalidData_ReturnBadRequest()
    {
        _controller.ModelState.AddModelError("error", "error");
        var result = _controller.CreateUser(new UserCreateDTO());

        Assert.That(result, Is.TypeOf<BadRequestObjectResult>());
    }

    [Test]
    public void CreateUser_ValidData_CallCreateUser()
    {
        _userMock.Setup(m => m.CreateUser(It.IsAny<UserCreateDTO>())).Returns(new User());

        _controller.CreateUser(new UserCreateDTO());

        _userMock.Verify(m => m.CreateUser(It.IsAny<UserCreateDTO>()));
    }

    [Test]
    public void CreateUser_ValidData_ReturnCreatedAtAction()
    {
        _userMock.Setup(m => m.CreateUser(It.IsAny<UserCreateDTO>())).Returns(new User());

        var result = _controller.CreateUser(new UserCreateDTO());

        Assert.That(result, Is.TypeOf<CreatedAtActionResult>());
    }

    [Test]
    public void DeleteUser_UserIdNotExists_ReturnNotFound()
    {
        var result = _controller.DeleteUser(1);

        Assert.That(result, Is.TypeOf<NotFoundResult>());
    }

    [Test]
    public void DeleteUser_UserIdExists_CallSoftDelete()
    {
        _userMock.Setup(m => m.FindUser(1)).Returns(new User());

        _controller.DeleteUser(1);

        _userMock.Verify(m => m.SoftDeleteUser(It.IsAny<User>()));
    }

    [Test]
    public void DeleteUser_UserIdExists_ReturnNoContent()
    {
        _userMock.Setup(m => m.FindUser(1)).Returns(new User());

        var result = _controller.DeleteUser(1);

        Assert.That(result, Is.TypeOf<NoContentResult>());
    }

    [Test]
    public void UpdateUser_InvalidData_ReturnBadRequest()
    {
        _controller.ModelState.AddModelError("error", "error");
        var result = _controller.UpdateUser(1, new UserUpdateDTO());

        Assert.That(result, Is.TypeOf<BadRequestObjectResult>());
    }

    [Test]
    public void UpdateUser_DifferentPhoneExists_ReturnBadRequest()
    {
        _userMock.Setup(m => m.FindUser(1)).Returns(new User { PhoneNumber = "1" });
        _userMock.Setup(m => m.IsPhoneNumberExists(It.IsAny<string>())).Returns(true);

        var result = _controller.UpdateUser(1, new UserUpdateDTO { Email = "", PhoneNumber = "0" });

        Assert.That(result, Is.TypeOf<ObjectResult>());
    }

    [Test]
    public void UpdateUser_DifferentPhoneNotExists_ReturnOk()
    {
        _userMock.Setup(m => m.FindUser(1)).Returns(new User { PhoneNumber = "1" });
        _userMock.Setup(m => m.IsPhoneNumberExists(It.IsAny<string>())).Returns(false);

        var result = _controller.UpdateUser(1, new UserUpdateDTO { Email = "", PhoneNumber = "0" });

        Assert.That(result, Is.TypeOf<OkResult>());
    }

    [Test]
    public void UpdateUser_DifferentEmailExists_ReturnBadRequest()
    {
        _userMock.Setup(m => m.FindUser(1)).Returns(new User { Email = "a@b.c" });
        _userMock.Setup(m => m.IsEmailExists(It.IsAny<string>())).Returns(true);

        var result = _controller.UpdateUser(1, new UserUpdateDTO { Email = "x@y.z" });

        Assert.That(result, Is.TypeOf<ObjectResult>());
    }

    [Test]
    public void UpdateUser_DifferentEmailNotExists_ReturnOk()
    {
        _userMock.Setup(m => m.FindUser(1)).Returns(new User { Email = "a@b.c" });
        _userMock.Setup(m => m.IsEmailExists(It.IsAny<string>())).Returns(false);

        var result = _controller.UpdateUser(1, new UserUpdateDTO { Email = "x@y.z" });

        Assert.That(result, Is.TypeOf<OkResult>());
    }

    [Test]
    public void UpdateUser_SameEmailAndPhone_ReturnOk()
    {
        _userMock.Setup(m => m.FindUser(1)).Returns(new User { Email = "a@b.c", PhoneNumber = "1" });

        var result = _controller.UpdateUser(1, new UserUpdateDTO { Email = "a@b.c", PhoneNumber = "1" });

        Assert.That(result, Is.TypeOf<OkResult>());
    }

    [Test]
    public void UpdateUser_ValidData_CallUpdateUser()
    {
        _userMock.Setup(m => m.FindUser(1)).Returns(new User());

        var result = _controller.UpdateUser(1, new UserUpdateDTO { Email = "" });

        _userMock.Verify(m => m.UpdateUser(It.IsAny<User>(), It.IsAny<UserUpdateDTO>()));
    }




}
