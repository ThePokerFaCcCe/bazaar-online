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


        /// <summary>
        /// Get a parent id and return a list of all of it's children recursively 
        /// </summary>
        /// <param name="parentId">Category's parent id</param>
        /// <param name="includeParent">Add Parent to the list</param>
        /// <returns>Parent category(if included) and it's children</returns>
        IEnumerable<Category> GetCategoryAndChildrenFlatten(int? parentId = null, bool includeParent = false);

        bool IsCategoryExists(int id);
    }
}
