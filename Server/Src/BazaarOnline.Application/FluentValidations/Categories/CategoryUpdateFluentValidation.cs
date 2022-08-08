using BazaarOnline.Application.DTOs.CategoryDTOs;
using BazaarOnline.Application.Interfaces.Categories;
using FluentValidation;

namespace BazaarOnline.Application.FluentValidations.Categories
{
    public class CategoryUpdateFluentValidation : AbstractValidator<CategoryUpdateDTO>
    {
        public CategoryUpdateFluentValidation(ICategoryService categoryService)
        {
            RuleFor(v => v.ParentId)
                .Must(id => id == null ? true : categoryService.IsCategoryExists((int)id))
                .WithMessage("دسته بندی با این آیدی یافت نشد");
        }
    }
}
