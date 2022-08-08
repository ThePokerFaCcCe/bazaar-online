using BazaarOnline.Domain.Entities.Categories;

namespace BazaarOnline.Domain.Interfaces.Categories
{
    public interface ICategoryRepository
    {
        IQueryable<Category> GetCategories();
        Category? FindCategory(int id);
        Category AddCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(Category category);
        void DeleteCategoryRange(IEnumerable<Category> categories);

        void Save();
    }
}
