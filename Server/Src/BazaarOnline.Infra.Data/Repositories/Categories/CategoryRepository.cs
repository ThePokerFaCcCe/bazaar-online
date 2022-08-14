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
            _context.Categories.Remove(category);
        }

        public Category? FindCategory(int id)
        {
            return _context.Categories.Find(id);
        }

        public IQueryable<Category> GetCategories()
        {
            return _context.Categories.AsQueryable();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateCategory(Category category)
        {
            _context.Categories.Update(category);
        }

        public void DeleteCategoryRange(IEnumerable<Category> categories)
        {
            _context.Categories.RemoveRange(categories);
        }

        public IQueryable<CategoryFeature> GetCategoryFeatures()
        {
            return _context.CategoryFeatures.AsQueryable();
        }

        public IQueryable<CategoryFeature> GetCategoryFeatures(int[] categoryIds)
        {
            return _context.CategoryFeatures
                .Where(cf => categoryIds.Contains(cf.CategoryId))
                .AsQueryable();
        }

        public CategoryFeature AddCategoryFeature(CategoryFeature categoryFeature)
        {
            return _context.CategoryFeatures.Add(categoryFeature).Entity;
        }

        public void AddCategoryFeatureRange(CategoryFeature[] categoryFeatures)
        {
            _context.CategoryFeatures.AddRange(categoryFeatures);
        }

        public void DeleteCategoryFeature(CategoryFeature categoryFeature)
        {
            _context.CategoryFeatures.Remove(categoryFeature);
        }

        public void DeleteCategoryFeatureRange(CategoryFeature[] categoryFeatures)
        {
            _context.CategoryFeatures.RemoveRange(categoryFeatures);
        }

        IQueryable<CategoryFeature> ICategoryRepository.GetCategoryFeatures(int categoryId)
        {
            return _context.CategoryFeatures
                .Where(cf => cf.CategoryId == categoryId)
                .AsQueryable();
        }
    }
}
