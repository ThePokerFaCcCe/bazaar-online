using System.Collections.Generic;
using System.Linq;
using BazaarOnline.Application.DTOs.CategoryDTOs;
using BazaarOnline.Application.Services.Categories;
using BazaarOnline.Application.ViewModels.Categories;
using BazaarOnline.Domain.Entities.Categories;
using BazaarOnline.Domain.Interfaces;
using Moq;
using NUnit.Framework;

namespace BazaarOnline.Application.UnitTests.Services.Categories;

[TestFixture]
public class CategoryServiceTests
{
    private Mock<IRepository> _repositoryMock;
    private CategoryService _categoryService;

    [SetUp]
    public void SetUp()
    {
        _repositoryMock = new Mock<IRepository>();
        _categoryService = new CategoryService(_repositoryMock.Object);

        _repositoryMock.Setup(m => m.GetAll<Category>()).Returns(new List<Category>
        {
            new Category{
                Id=1,
            },
            new Category{
                Id=11,
                ParentId=1,
            },
            new Category{
                Id=111,
                ParentId=11,
            },
            new Category{Id=2},
        }.AsQueryable());
    }

    [Test]
    public void CreateCategory_WhenCalled_CallAddAndSave()
    {
        _categoryService.CreateCategory(new CategoryCreateDTO());

        _repositoryMock.Verify(m => m.Add<Category>(It.IsAny<Category>()));
        _repositoryMock.Verify(m => m.Save());
    }

    [Test]
    public void DeleteCategory_WhenCalled_CallDeleteAndSave()
    {
        _categoryService.DeleteCategory(new Category());

        _repositoryMock.Verify(m => m.RemoveRange<Category>(It.IsAny<IEnumerable<Category>>()));
        _repositoryMock.Verify(m => m.Save());
    }

    [Test]
    public void UpdateCategory_WhenCalled_CallUpdateAndSave()
    {
        _categoryService.UpdateCategory(new Category(), new CategoryUpdateDTO());

        _repositoryMock.Verify(m => m.Update<Category>(It.IsAny<Category>()));
        _repositoryMock.Verify(m => m.Save());
    }

    [Test]
    public void FindCategory_CategoryIdExists_ReturnCategory()
    {
        _repositoryMock.Setup(m => m.Get<Category>(1)).Returns(new Category());

        var result = _categoryService.FindCategory(1);

        Assert.That(result, Is.TypeOf<Category>());
    }

    [Test]
    public void FindCategory_CategoryIdNotExists_ReturnNull()
    {
        _repositoryMock.Setup(m => m.Get<Category>(1)).Returns(value: null);

        var result = _categoryService.FindCategory(1);

        Assert.That(result, Is.Null);
    }

    [Test]
    public void IsCategoryExists_CategoryIdExists_ReturnTrue()
    {
        _repositoryMock.Setup(m => m.GetAll<Category>()).Returns(new List<Category>{
            new Category{Id=1},
        }.AsQueryable());

        var result = _categoryService.IsCategoryExists(1);

        Assert.That(result, Is.True);
    }

    [Test]
    public void IsCategoryExists_CategoryIdNotExists_ReturnFalse()
    {
        _repositoryMock.Setup(m => m.GetAll<Category>())
            .Returns(new List<Category>().AsQueryable());

        var result = _categoryService.IsCategoryExists(1);

        Assert.That(result, Is.False);
    }

    [Test]
    public void GetCategoryDetail_CategoryIdExists_ReturnCategory()
    {
        _repositoryMock.Setup(m => m.GetAll<Category>()).Returns(new List<Category>{
            new Category{Id=1,ChildCategories=new List<Category>()},
        }.AsQueryable());

        var result = _categoryService.GetCategoryDetail(1);

        Assert.That(result, Is.TypeOf<CategoryDetailViewModel>());
    }

    [Test]
    public void GetCategoryDetail_CategoryIdNotExists_ReturnNull()
    {
        _repositoryMock.Setup(m => m.GetAll<Category>())
            .Returns(new List<Category>().AsQueryable());

        var result = _categoryService.GetCategoryDetail(1);

        Assert.That(result, Is.Null);
    }

    [Test]
    [TestCase(1, new[] { 1, 11, 111 })]
    [TestCase(11, new[] { 11, 111 })]
    [TestCase(2, new[] { 2 })]
    public void GetCategoryAndChildrenFlatten_IncludeParentTrue_EXPECTED_RESULT(int? parentId, int[] expected)
    {
        var categories = _categoryService.GetCategoryAndChildrenFlatten(parentId, true);

        var result = categories.Select(c => c.Id).ToList();

        Assert.That(result, Is.EquivalentTo(expected));
    }

    [Test]
    [TestCase(1, new[] { 11, 111 })]
    [TestCase(11, new[] { 111 })]
    [TestCase(2, new int[] { })]
    public void GetCategoryAndChildrenFlatten_IncludeParentFalse_EXPECTED_RESULT(int? parentId, int[] expected)
    {
        var categories = _categoryService.GetCategoryAndChildrenFlatten(parentId, false);

        var result = categories.Select(c => c.Id).ToList();

        Assert.That(result, Is.EquivalentTo(expected));
    }

}
