using System.Collections.Generic;
using System.Linq;
using BazaarOnline.Application.DTOs.PaginationDTO;
using BazaarOnline.Application.DTOs.Users.UserDTOs;
using BazaarOnline.Application.Services.Users;
using BazaarOnline.Domain.Entities.Users;
using BazaarOnline.Domain.Interfaces;
using Moq;
using NUnit.Framework;

namespace BazaarOnline.Application.UnitTests.Services.Users;

[TestFixture]
public class UserService_GetUserListDetailsTests
{
    private Mock<IRepository> _repositoryMock;
    private UserService _userService;

    private User user;

    [SetUp]
    public void SetUp()
    {
        _repositoryMock = new Mock<IRepository>();
        _userService = new UserService(_repositoryMock.Object);

        user = new User { Id = 1 };
        _repositoryMock.Setup(m => m.GetAll<User>()).Returns(new List<User>{
            user,
        }.AsQueryable());
    }

    [Test]
    public void GetUserListDetails_FilterIsDeletedTrueAndHasUser_UserExistsInResult()
    {
        user.IsDeleted = true;

        var result = _userService.GetUserListDetails(new UserFilterDTO
        {
            IsDeleted = true
        }, new PaginationFilterDTO());

        Assert.Contains(user.Id, result.Content.Select(r => r.Id).ToList());
    }

    [Test]
    public void GetUserListDetails_FilterIsDeletedTrueAndHasNotUser_ReturnEmptyResult()
    {
        user.IsDeleted = false;

        var result = _userService.GetUserListDetails(new UserFilterDTO
        {
            IsDeleted = true
        }, new PaginationFilterDTO());

        Assert.That(result.Content.Count, Is.EqualTo(0));
    }

    [Test]
    public void GetUserListDetails_FilterIsActiveTrueAndHasUser_UserExistsInResult()
    {
        user.IsActive = true;

        var result = _userService.GetUserListDetails(new UserFilterDTO
        {
            IsActive = true
        }, new PaginationFilterDTO());

        Assert.Contains(user.Id, result.Content.Select(r => r.Id).ToList());
    }

    [Test]
    public void GetUserListDetails_FilterIsActiveTrueAndHasNotUser_ReturnEmptyResult()
    {
        user.IsActive = false;

        var result = _userService.GetUserListDetails(new UserFilterDTO
        {
            IsActive = true
        }, new PaginationFilterDTO());

        Assert.That(result.Content.Count, Is.EqualTo(0));
    }

    [Test]
    public void GetUserListDetails_FilterEmailAndHasUser_UserExistsInResult()
    {
        user.Email = "a@b.com";

        var result = _userService.GetUserListDetails(new UserFilterDTO
        {
            Email = "a@b"
        }, new PaginationFilterDTO());

        Assert.Contains(user.Id, result.Content.Select(r => r.Id).ToList());
    }

    [Test]
    public void GetUserListDetails_FilterEmailAndHasNotUser_ReturnEmptyResult()
    {
        user.Email = string.Empty;

        var result = _userService.GetUserListDetails(new UserFilterDTO
        {
            Email = "a@b.com"
        }, new PaginationFilterDTO());

        Assert.That(result.Content.Count, Is.EqualTo(0));
    }

    [Test]
    public void GetUserListDetails_FilterNameFirstNameAndHasUser_UserExistsInResult()
    {
        user.FirstName = "matin";
        user.LastName = "khaleghi";

        var result = _userService.GetUserListDetails(new UserFilterDTO
        {
            Name = "mat"
        }, new PaginationFilterDTO());

        Assert.Contains(user.Id, result.Content.Select(r => r.Id).ToList());
    }

    [Test]
    public void GetUserListDetails_FilterNameLastNameAndHasUser_UserExistsInResult()
    {
        user.FirstName = "matin";
        user.LastName = "khaleghi";

        var result = _userService.GetUserListDetails(new UserFilterDTO
        {
            Name = "kh"
        }, new PaginationFilterDTO());

        Assert.Contains(user.Id, result.Content.Select(r => r.Id).ToList());
    }

    [Test]
    public void GetUserListDetails_FilterNameAndHasNotUser_ReturnEmptyResult()
    {
        user.FirstName = string.Empty;
        user.LastName = string.Empty;

        var result = _userService.GetUserListDetails(new UserFilterDTO
        {
            Name = "matin khaleghi"
        }, new PaginationFilterDTO());

        Assert.That(result.Content.Count, Is.EqualTo(0));
    }

}
