using System.Collections.Generic;
using BazaarOnline.API.Controllers.Advertisements;
using BazaarOnline.Application.DTOs.CategoryDTOs;
using BazaarOnline.Application.Interfaces.Categories;
using BazaarOnline.Application.ViewModels.Categories;
using BazaarOnline.Domain.Entities.Categories;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace BazaarOnline.API.UnitTests.Controllers.Advertisements;

[TestFixture]
public class CategoriesControllerTests
{
    private Mock<ICategoryService> _categoryServiceMock;
    private CategoriesController _controller;

    [SetUp]
    public void SetUp()
    {
        _categoryServiceMock = new Mock<ICategoryService>();
        _controller = new CategoriesController(_categoryServiceMock.Object);
    }

    [Test]
    public void GetCategoryList_WhenCalled_ReturnOkListCategoryListDetailViewModel()
    {
        var result = _controller.GetCategoryList();

        Assert.That(result.Result, Is.TypeOf<OkObjectResult>());
        Assert.That(result, Is.TypeOf<ActionResult<List<CategoryListDetailViewModel>>>());
    }

    [Test]
    public void GetCategoryDetail_CategoryExists_ReturnOkCategoryDetailViewModel()
    {
        _categoryServiceMock.Setup(m => m.GetCategoryDetail(1))
            .Returns(new CategoryDetailViewModel());

        var result = _controller.GetCategoryDetail(1);

        Assert.That(result.Result, Is.TypeOf<OkObjectResult>());
        Assert.That(result, Is.TypeOf<ActionResult<CategoryDetailViewModel>>());
    }

    [Test]
    public void GetCategoryDetail_CategoryNotExists_ReturnNotFound()
    {
        _categoryServiceMock.Setup(m => m.GetCategoryDetail(1))
            .Returns(value: null);

        var result = _controller.GetCategoryDetail(1);

        Assert.That(result.Result, Is.TypeOf<NotFoundResult>());
    }

    [Test]
    public void GetCategoryChildren_CategoryExists_ReturnOkListCategoryListDetailViewModel()
    {
        _categoryServiceMock.Setup(m => m.FindCategory(1)).Returns(new Category());

        var result = _controller.GetCategoryChildren(1);

        Assert.That(result.Result, Is.TypeOf<OkObjectResult>());
        Assert.That(result, Is.TypeOf<ActionResult<List<CategoryListDetailViewModel>>>());
    }

    [Test]
    public void GetCategoryChildren_CategoryNotExists_ReturnNotFound()
    {
        _categoryServiceMock.Setup(m => m.FindCategory(1)).Returns(value: null);

        var result = _controller.GetCategoryChildren(1);

        Assert.That(result.Result, Is.TypeOf<NotFoundResult>());
    }

    [Test]
    public void CreateCategory_ValidData_ReturnCreatedAtAction()
    {
        _categoryServiceMock.Setup(m => m.CreateCategory(It.IsAny<CategoryCreateDTO>()))
            .Returns(new Category());

        var result = _controller.CreateCategory(new CategoryCreateDTO());

        Assert.That(result, Is.TypeOf<CreatedAtActionResult>());
    }

    [Test]
    public void CreateCategory_ValidData_CallCreateMethod()
    {
        _categoryServiceMock.Setup(m => m.CreateCategory(It.IsAny<CategoryCreateDTO>()))
            .Returns(new Category());

        var result = _controller.CreateCategory(new CategoryCreateDTO());

        _categoryServiceMock.Verify(m => m.CreateCategory(It.IsAny<CategoryCreateDTO>()));
    }

    [Test]
    public void CreateCategory_InvalidData_ReturnBadRequest()
    {
        _controller.ModelState.AddModelError("error", "error");
        var result = _controller.CreateCategory(new CategoryCreateDTO());

        Assert.That(result, Is.TypeOf<BadRequestObjectResult>());
    }

    [Test]
    public void UpdateCategory_ValidData_ReturnOk()
    {
        _categoryServiceMock.Setup(m => m.FindCategory(1))
            .Returns(new Category());

        var result = _controller.UpdateCategory(1, new CategoryUpdateDTO());

        Assert.That(result, Is.TypeOf<OkResult>());
    }

    [Test]
    public void UpdateCategory_CategoryNotExists_ReturnNotFound()
    {
        _categoryServiceMock.Setup(m => m.FindCategory(1))
            .Returns(value: null);

        var result = _controller.UpdateCategory(1, new CategoryUpdateDTO());

        Assert.That(result, Is.TypeOf<NotFoundResult>());
    }

    [Test]
    public void UpdateCategory_ValidData_CallUpdateMethod()
    {
        _categoryServiceMock.Setup(m => m.FindCategory(1))
            .Returns(new Category());

        var result = _controller.UpdateCategory(1, new CategoryUpdateDTO());

        _categoryServiceMock.Verify(m => m.UpdateCategory(
            It.IsAny<Category>(), It.IsAny<CategoryUpdateDTO>()));
    }

    [Test]
    public void UpdateCategory_InvalidData_ReturnBadRequest()
    {
        _controller.ModelState.AddModelError("error", "error");
        var result = _controller.UpdateCategory(1, new CategoryUpdateDTO());

        Assert.That(result, Is.TypeOf<BadRequestObjectResult>());
    }


    [Test]
    public void DeleteCategory_CategoryExists_ReturnOk()
    {
        _categoryServiceMock.Setup(m => m.FindCategory(1))
            .Returns(new Category());

        var result = _controller.DeleteCategory(1);

        Assert.That(result, Is.TypeOf<NoContentResult>());
    }

    [Test]
    public void DeleteCategory_CategoryNotExists_ReturnNotFound()
    {
        _categoryServiceMock.Setup(m => m.FindCategory(1))
            .Returns(value: null);

        var result = _controller.DeleteCategory(1);

        Assert.That(result, Is.TypeOf<NotFoundResult>());
    }

    [Test]
    public void DeleteCategory_CategoryExists_CallUpdateMethod()
    {
        _categoryServiceMock.Setup(m => m.FindCategory(1))
            .Returns(new Category());

        var result = _controller.DeleteCategory(1);

        _categoryServiceMock.Verify(m => m.DeleteCategory(It.IsAny<Category>()));
    }

}
