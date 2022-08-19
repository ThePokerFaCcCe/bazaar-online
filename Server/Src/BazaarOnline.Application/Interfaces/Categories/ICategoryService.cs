using BazaarOnline.Application.DTOs.CategoryDTOs;
using BazaarOnline.Application.ViewModels.Categories;
using BazaarOnline.Application.ViewModels.Features;
using BazaarOnline.Domain.Entities.Categories;
using BazaarOnline.Domain.Entities.Features;

namespace BazaarOnline.Application.Interfaces.Categories
{
    public interface ICategoryService
    {
        List<CategoryListDetailViewModel> GetCategoryListDetails();
        List<CategoryListDetailViewModel> GetCategoryChildrenDetail(
            int? parentId = null, bool includeParent = false);
        CategoryDetailViewModel? GetCategoryDetail(int id);
        Category? FindCategory(int id, bool includeChildren = false);
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

        /// <summary>
        /// Get category id and return list of it's parents hirearchy
        /// </summary>
        /// <param name="categoryId">category id</param>
        /// <param name="includeSelf">add category id to list</param>
        /// <returns>self category(if included) and it's parent</returns>
        IEnumerable<Category> GetCategoryAndParentFlatten(int? categoryId, bool includeSelf = false);

        bool IsCategoryExists(int id);

        #region CategoryFeature

        List<FeatureDetailViewModel> GetCategoryFeatureDetails(Category category);
        List<FeatureDetailViewModel> GetCategoryFeatureDetailsHierarchy(Category category);
        IEnumerable<Feature> GetCategoryFeaturesHierarchy(Category category);
        void UpdateCategoryFeatures(Category category, CategoryFeatureAddDTO addDTO);

        #endregion
    }
}
