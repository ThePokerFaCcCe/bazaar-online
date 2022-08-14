using BazaarOnline.Domain.Entities.Categories;

namespace BazaarOnline.Domain.Interfaces.Categories
{
    public interface ICategoryRepository
    {
        #region Category

        IQueryable<Category> GetCategories();
        Category? FindCategory(int id);
        Category AddCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(Category category);
        void DeleteCategoryRange(IEnumerable<Category> categories);

        #endregion

        #region CategoryFeatures

        IQueryable<CategoryFeature> GetCategoryFeatures();
        IQueryable<CategoryFeature> GetCategoryFeatures(int categoryId);
        IQueryable<CategoryFeature> GetCategoryFeatures(int[] categoryIds);
        CategoryFeature AddCategoryFeature(CategoryFeature categoryFeature);
        void AddCategoryFeatureRange(CategoryFeature[] categoryFeatures);
        void DeleteCategoryFeature(CategoryFeature categoryFeature);
        void DeleteCategoryFeatureRange(CategoryFeature[] categoryFeatures);

        #endregion
        void Save();
    }
}
