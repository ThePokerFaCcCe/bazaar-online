using BazaarOnline.Application.DTOs.CategoryDTOs;
using BazaarOnline.Application.FluentValidations.Categories;
using BazaarOnline.Application.Interfaces.Categories;
using FluentValidation.TestHelper;
using Moq;
using NUnit.Framework;

namespace BazaarOnline.Application.UnitTests.FluentValidations.Categories;

[TestFixture]
public class CategoryCreateFluentValidationTests
{
    private Mock<ICategoryService> _categoryServiceMock;
    private CategoryCreateFluentValidation _validator;

    [SetUp]
    public void SetUp()
    {
        _categoryServiceMock = new Mock<ICategoryService>();
        _validator = new CategoryCreateFluentValidation(_categoryServiceMock.Object);
    }

    [Test]
    public void Validate_ParentIdExists_NoValidationErrorsHappen()
    {
        _categoryServiceMock.Setup(m => m.IsCategoryExists(1)).Returns(true);

        var result = _validator.TestValidate(new CategoryCreateDTO { ParentId = 1 });

        result.ShouldNotHaveAnyValidationErrors();
    }

    [Test]
    public void Validate_ParentIsNull_NoValidationErrorsHappen()
    {
        var result = _validator.TestValidate(new CategoryCreateDTO { ParentId = null });

        result.ShouldNotHaveAnyValidationErrors();
    }

    [Test]
    public void Validate_ParentIdNotExists_ValidationErrorForParentId()
    {
        _categoryServiceMock.Setup(m => m.IsCategoryExists(1)).Returns(false);

        var result = _validator.TestValidate(new CategoryCreateDTO { ParentId = 1 });

        result.ShouldHaveValidationErrorFor(v => v.ParentId);
    }

}
