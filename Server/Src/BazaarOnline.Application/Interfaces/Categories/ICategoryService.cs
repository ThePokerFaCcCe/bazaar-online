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

        bool IsCategoryExists(int id);

        #region CategoryFeature

        List<FeatureDetailViewModel> GetCategoryFeatureDetails(Category category);
        List<FeatureDetailViewModel> GetCategoryFeatureDetailsHierarchy(Category category);
        IEnumerable<Feature> GetCategoryFeaturesHierarchy(Category category);
        void UpdateCategoryFeatures(Category category, CategoryFeatureAddDTO addDTO);

        #endregion
    }
}
