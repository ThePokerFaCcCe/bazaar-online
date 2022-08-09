using BazaarOnline.Application.DTOs.CategoryDTOs;
using BazaarOnline.Application.Interfaces.Categories;
using BazaarOnline.Application.Utils.Extentions;
using BazaarOnline.Application.ViewModels.Categories;
using BazaarOnline.Domain.Entities.Categories;
using BazaarOnline.Domain.Interfaces.Categories;
using Microsoft.EntityFrameworkCore;

namespace BazaarOnline.Application.Services.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public Category CreateCategory(CategoryCreateDTO createDTO)
        {
            createDTO.TrimStrings();

            var category = new Category();
            category.FillFromObject(createDTO);

            _categoryRepository.AddCategory(category);
            _categoryRepository.Save();

            return category;
        }

        public void DeleteCategory(Category category)
        {
            _categoryRepository.DeleteCategoryRange(
                GetCategoryAndChildrenFlatten(category.Id, true)
            );
            _categoryRepository.Save();
        }

        public Category? FindCategory(int id)
        {
            return _categoryRepository.FindCategory(id);
        }

        public List<CategoryListDetailViewModel> GetCategoryChildrenDetail(
            int? parentId = null, bool includeParent = false)
        {
            return GetCategoryAndChildrenFlatten(parentId, includeParent)
                .Select(c =>
                    ModelHelper.CreateAndFillFromObject
                        <CategoryListDetailViewModel, Category>(c)
                ).ToList();
        }

        public CategoryDetailViewModel? GetCategoryDetail(int id)
        {
            return _categoryRepository.GetCategories()
                .Include(c => c.ChildCategories)
                .Include(c => c.ParentCategory)
                .Where(c => c.Id == id)
                .AsEnumerable()
                .Select(c =>
                {
                    var detail = ModelHelper.CreateAndFillFromObject
                        <CategoryDetailViewModel, Category>(c);
                    detail.Parent = c.ParentCategory == null ? null :
                        ModelHelper.CreateAndFillFromObject
                            <CategoryParentDetailViewModel, Category>(c.ParentCategory, false);

                    detail.Children = c.ChildCategories.Select(ch =>
                            ModelHelper.CreateAndFillFromObject
                                <CategoryChildDetailViewModel, Category>(ch, false)
                    ).ToList();

                    return detail;
                }).SingleOrDefault();
        }

        public List<CategoryListDetailViewModel> GetCategoryListDetails()
        {
            return GetCategoryAndChildrenFlatten(null, true)
                .Select(c =>
                    ModelHelper.CreateAndFillFromObject
                        <CategoryListDetailViewModel, Category>(c)
                ).ToList();
        }

        public bool IsCategoryExists(int id)
        {
            return _categoryRepository.GetCategories()
                .Any(c => c.Id == id);
        }

        public void UpdateCategory(Category category, CategoryUpdateDTO updateDTO)
        {
            category.FillFromObject(updateDTO);

            _categoryRepository.UpdateCategory(category);
            _categoryRepository.Save();
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
            if (allCategories == null) allCategories = _categoryRepository.GetCategories().ToList();
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

    }
}
