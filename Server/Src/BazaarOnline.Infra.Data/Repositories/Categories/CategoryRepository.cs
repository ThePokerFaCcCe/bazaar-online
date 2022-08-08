using BazaarOnline.Domain.Entities.Categories;
using BazaarOnline.Infra.Data.Contexts;

namespace BazaarOnline.Domain.Interfaces.Categories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly BazaarDbContext _context;

        public CategoryRepository(BazaarDbContext context)
        {
            _context = context;
        }

        public Category AddCategory(Category category)
        {
            return _context.Categories.Add(category).Entity;
        }

        public void DeleteCategory(Category category)
        {
            _context.Categories.RemoveRange(GetCategoryAndChildrenFlatten(category.Id, true));
        }

        public Category? FindCategory(int id)
        {
            return _context.Categories.Find(id);
        }

        public IQueryable<Category> GetCategories()
        {
            return _context.Categories.AsQueryable();
        }

        public IEnumerable<Category> GetCategoryAndChildrenFlatten(
            int? parentId = null, bool includeParent = false)
        {
            return _GetCategoryAndChildrenFlatten(parentId: parentId, includeParent: includeParent);
        }

        private IEnumerable<Category> _GetCategoryAndChildrenFlatten(
            int? parentId = null, bool includeParent = false,
            IEnumerable<Category>? allCategories = null,
            List<Category>? selectedCategories = null)
        {
            if (allCategories == null) allCategories = _context.Categories.ToList();
            if (selectedCategories == null)
            {
                selectedCategories = new List<Category>();
                if (includeParent)
                {
                    selectedCategories.AddRange(
                        _context.Categories.Where(c => c.Id == parentId)
                    );
                }
            }
            allCategories.Where(c => c.ParentId == parentId).ToList()
            .ForEach(c =>
            {
                selectedCategories.Add(c);
                _GetCategoryAndChildrenFlatten(c.Id, includeParent, allCategories, selectedCategories);
            });

            return selectedCategories;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateCategory(Category category)
        {
            _context.Categories.Update(category);
        }
    }
}
