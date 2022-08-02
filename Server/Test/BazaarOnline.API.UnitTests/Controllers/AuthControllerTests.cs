using BazaarOnline.API.Controllers;
using BazaarOnline.Application.DTOs;
using BazaarOnline.Application.DTOs.AuthDTOs;
using BazaarOnline.Application.DTOs.JwtDTOs;
using BazaarOnline.Application.DTOs.Users.UserDTOs;
using BazaarOnline.Application.Interfaces.Auth;
using BazaarOnline.Application.Interfaces.Users;
using BazaarOnline.Domain.Entities.Users;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace BazaarOnline.API.UnitTests.Controllers;

[TestFixture]
public class AuthControllerTests
{
    private Mock<IAuthService> _authMock;
    private Mock<IUserService> _userMock;
    private AuthController _controller;

    [SetUp]
    public void SetUp()
    {
        _authMock = new Mock<IAuthService>();
        _userMock = new Mock<IUserService>();
        _controller = new AuthController(_authMock.Object, _userMock.Object);
    }

    [Test]
    public void Register_ModelIsValid_CallCreateUserMethod()
    {
        var result = _controller.Register(new UserCreateDTO());

        _userMock.Verify(m => m.CreateUser(It.IsAny<UserCreateDTO>()));
    }

    [Test]
    public void Register_ModelIsValid_ReturnCreatedAtAction()
    {
        var result = _controller.Register(new UserCreateDTO());

        Assert.That(result, Is.TypeOf<CreatedAtActionResult>());
    }

    [Test]
    public void Register_ModelIsInvalid_ReturnBadRequest()
    {
        _controller.ModelState.AddModelError("error", "error");
        var result = _controller.Register(new UserCreateDTO());

        Assert.That(result, Is.TypeOf<BadRequestObjectResult>());
    }



    [Test]
    public void CreateToken_ModelIsValid_CallCreateTokenMethod()
    {
        var result = _controller.CreateToken(new UserLoginDTO());

        _authMock.Verify(m => m.CreateToken(It.IsAny<User>()));
    }

    [Test]
    public void CreateToken_ModelIsValid_ReturnGeneratedTokenDTO()
    {
        var result = _controller.CreateToken(new UserLoginDTO());

        Assert.That(result, Is.TypeOf<ActionResult<GeneratedTokenDTO>>());
    }

    [Test]
    public void CreateToken_ModelIsInvalid_ReturnBadRequest()
    {
        _controller.ModelState.AddModelError("error", "error");
        var result = _controller.CreateToken(new UserLoginDTO());

        Assert.That(result.Result, Is.TypeOf<BadRequestObjectResult>());
    }


    [Test]
    public void EmailActiveCode_ModelIsValid_CallRegisterUserByEmailMethod()
    {
        var result = _controller.EmailActiveCode(new EmailActiveCodeDTO());

        _authMock.Verify(m => m.RegisterUserByEmail(It.IsAny<User>()));
    }

    [Test]
    public void EmailActiveCode_ModelIsValid_ReturnCodeSentResultDTO()
    {
        var result = _controller.EmailActiveCode(new EmailActiveCodeDTO());

        Assert.That(result, Is.TypeOf<ActionResult<CodeSentResultDTO>>());
    }

    [Test]
    public void EmailActiveCode_ModelIsInvalid_ReturnBadRequest()
    {
        _controller.ModelState.AddModelError("error", "error");
        var result = _controller.EmailActiveCode(new EmailActiveCodeDTO());

        Assert.That(result.Result, Is.TypeOf<BadRequestObjectResult>());
    }



    [Test]
    public void Activate_ModelIsValid_CallActivateUserMethod()
    {
        var result = _controller.Activate(new ActivateUserEmailDTO());

        _userMock.Verify(m => m.ActivateUser(It.IsAny<User>()));
    }

    [Test]
    public void Activate_ModelIsValid_ReturnOperationResultDTO()
    {
        var result = _controller.Activate(new ActivateUserEmailDTO());

        Assert.That(result, Is.TypeOf<ActionResult<OperationResultDTO>>());
    }

    [Test]
    public void Activate_ModelIsInvalid_ReturnBadRequest()
    {
        _controller.ModelState.AddModelError("error", "error");
        var result = _controller.Activate(new ActivateUserEmailDTO());

        Assert.That(result.Result, Is.TypeOf<BadRequestObjectResult>());
    }



}
