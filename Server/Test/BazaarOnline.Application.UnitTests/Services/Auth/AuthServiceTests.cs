using System;
using BazaarOnline.Application.DTOs.AuthDTOs;
using BazaarOnline.Application.Interfaces.Senders;
using BazaarOnline.Application.Services.Auth;
using BazaarOnline.Domain.Entities.Users;
using BazaarOnline.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;

namespace BazaarOnline.Application.UnitTests.Services.Auth;

[TestFixture]
public class AuthServiceTests
{
    private Mock<IRepository> _repository;
    private Mock<IEmailService> _emailMock;
    private AuthService _authService;

    private User user;
    private ActiveCode activeCode;

    [SetUp]
    public void SetUp()
    {
        _repository = new Mock<IRepository>();
        _emailMock = new Mock<IEmailService>();
        _authService = new AuthService(new Mock<IConfiguration>().Object, _emailMock.Object, _repository.Object);

        user = new User { Email = "a@b.com" };

        activeCode = new ActiveCode { ExpireDate = DateTime.Now };
        _repository.Setup(m => m.Add<ActiveCode>(It.IsAny<ActiveCode>())).Returns(activeCode);
    }

    #region RegisterUserByEmail

    [Test]
    public void RegisterUserByEmail_WhenCalled_CreateActiveCode()
    {
        _authService.RegisterUserByEmail(user);

        _repository.Verify(m => m.Add<ActiveCode>(It.IsAny<ActiveCode>()));
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
        var result = _authService.RegisterUserByEmail(user);

        Assert.That(result.ExpireDate, Is.EqualTo(activeCode.ExpireDate));
    }

    #endregion
}
