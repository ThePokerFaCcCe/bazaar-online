using BazaarOnline.Domain.Entities.Categories;

namespace BazaarOnline.Domain.Interfaces.Categories
{
    public interface ICategoryRepository
    {
        IQueryable<Category> GetCategories();

        /// <summary>
        /// Get a parent id and return a list of all of it's children recursively 
        /// </summary>
        /// <param name="parentId">Category's parent id</param>
        /// <param name="includeParent">Add Parent to the list</param>
        /// <returns>Parent category(if included) and it's children</returns>
        IEnumerable<Category> GetCategoryAndChildrenFlatten(int? parentId = null, bool includeParent = false);

        Category? FindCategory(int id);
        Category AddCategory(Category category);
        void UpdateCategory(Category category);

        /// <summary>
        /// Delete a category and All of it's children
        /// </summary>
        /// <param name="category"></param>
        void DeleteCategory(Category category);

        void Save();
    }
}
