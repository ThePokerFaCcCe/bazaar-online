using System;
using BazaarOnline.Application.DTOs.AuthDTOs;
using BazaarOnline.Application.Interfaces.Senders;
using BazaarOnline.Application.Interfaces.Users;
using BazaarOnline.Application.Services.Auth;
using BazaarOnline.Domain.Entities.Users;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;

namespace BazaarOnline.Application.UnitTests.Services.Auth;

[TestFixture]
public class AuthServiceTests
{
    private Mock<IActiveCodeService> _activeCodeMock;
    private Mock<IEmailService> _emailMock;
    private AuthService _authService;

    private User user;

    [SetUp]
    public void SetUp()
    {
        _activeCodeMock = new Mock<IActiveCodeService>();
        _emailMock = new Mock<IEmailService>();
        _authService = new AuthService(_activeCodeMock.Object, new Mock<IConfiguration>().Object, _emailMock.Object);

        user = new User { Email = "a@b.com" };
        _activeCodeMock.Setup(m => m.CreateActiveCode(It.IsAny<string>())).Returns(new ActiveCode());
    }

    #region RegisterUserByEmail

    [Test]
    public void RegisterUserByEmail_WhenCalled_CreateActiveCode()
    {
        _authService.RegisterUserByEmail(user);

        _activeCodeMock.Verify(m => m.CreateActiveCode(user.Email));
    }

    [Test]
    public void RegisterUserByEmail_WhenCalled_SendEmail()
    {
        _authService.RegisterUserByEmail(user);

        _emailMock.Verify(m => m.SendActiveCode(user, It.IsAny<ActiveCode>()));

    }

    [Test]
    public void RegisterUserByEmail_WhenCalled_ReturnOperationResultDTO()
    {
        var result = _authService.RegisterUserByEmail(user);

        Assert.That(result, Is.TypeOf<CodeSentResultDTO>());
    }

    [Test]
    public void RegisterUserByEmail_WhenCalled_ReturnCorrectExpireDate()
    {
        ActiveCode activeCode = new ActiveCode { ExpireDate = DateTime.Now };

        _activeCodeMock.Setup(m => m.CreateActiveCode(user.Email)).Returns(activeCode);

        var result = _authService.RegisterUserByEmail(user);

        Assert.That(result.ExpireDate, Is.EqualTo(activeCode.ExpireDate));
    }

    #endregion
}
