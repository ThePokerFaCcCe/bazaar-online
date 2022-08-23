using BazaarOnline.Application.Interfaces.Categories;
using BazaarOnline.Domain.Entities.Categories;
using BazaarOnline.Domain.Interfaces;

namespace BazaarOnline.Application.Services.Categories
{
    public class CategoryHirearchyService : ICategoryHirearchyService
    {
        private readonly IRepository _repository;

        public CategoryHirearchyService(IRepository repository)
        {
            _repository = repository;
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
            if (allCategories == null) allCategories = _repository.GetAll<Category>().ToList();
            if (selectedCategories == null)
            {
                selectedCategories = new List<Category>();
                if (includeParent)
                {
                    selectedCategories.AddRange(
                        allCategories.Where(c => c.Id == parentId)
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


        public IEnumerable<Category> GetCategoryAndParentFlatten(int? categoryId, bool includeSelf = false)
        {
            // TODO: Refactor this method!
            var allCategories = _repository.GetAll<Category>();

            var hierarchy = new List<Category>();
            var ccategory = allCategories.SingleOrDefault(c => c.Id == categoryId);

            if (ccategory == null) return hierarchy;
            hierarchy.Add(ccategory);

            while (ccategory.ParentId != null)
            {
                ccategory = allCategories.Single(c => c.Id == ccategory.ParentId);
                hierarchy.Add(ccategory);
            }

            return hierarchy;
        }
    }
}
