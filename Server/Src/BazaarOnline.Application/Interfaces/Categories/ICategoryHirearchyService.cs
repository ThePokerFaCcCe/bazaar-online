using BazaarOnline.Domain.Entities.Categories;

namespace BazaarOnline.Application.Interfaces.Categories
{
    public interface ICategoryHirearchyService
    {

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
        IEnumerable<Category> GetCategoryAndParentFlatten(int categoryId, bool includeSelf = false);

    }
}
