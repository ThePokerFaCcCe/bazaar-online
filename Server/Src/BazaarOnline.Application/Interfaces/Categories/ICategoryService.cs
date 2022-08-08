using BazaarOnline.Application.DTOs.CategoryDTOs;
using BazaarOnline.Application.ViewModels.Categories;
using BazaarOnline.Domain.Entities.Categories;

namespace BazaarOnline.Application.Interfaces.Categories
{
    public interface ICategoryService
    {
        List<CategoryListDetailViewModel> GetCategoryListDetails();
        List<CategoryListDetailViewModel> GetCategoryChildrenDetail(
            int? parentId = null, bool includeParent = false);
        CategoryDetailViewModel? GetCategoryDetail(int id);
        Category? FindCategory(int id);
        Category CreateCategory(CategoryCreateDTO createDTO);
        void UpdateCategory(Category category, CategoryUpdateDTO updateDTO);

        /// <summary>
        /// Delete a category and All of it's children
        /// </summary>
        /// <param name="category"></param>
        void DeleteCategory(Category category);

        bool IsCategoryExists(int id);
    }
}
