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
            _categoryRepository.DeleteCategory(category);
            _categoryRepository.Save();
        }

        public Category? FindCategory(int id)
        {
            ;
            return _categoryRepository.FindCategory(id);
        }

        public List<CategoryListDetailViewModel> GetCategoryChildrenDetail(
            int? parentId = null, bool includeParent = false)
        {
            return _categoryRepository.GetCategoryAndChildrenFlatten(parentId, includeParent)
                .Select(c => new CategoryListDetailViewModel
                {
                    Id = c.Id,
                    ParentId = c.ParentId,
                    Title = c.Title,
                }).ToList();
        }

        public CategoryDetailViewModel? GetCategoryDetail(int id)
        {
            return _categoryRepository.GetCategories()
                .Include(c => c.ChildCategories)
                .Include(c => c.ParentCategory)
                .Where(c => c.Id == id)
                .Select(c => new CategoryDetailViewModel
                {
                    Id = c.Id,
                    Title = c.Title,
                    Parent = c.ParentCategory == null ? null : new CategoryParentDetailViewModel
                    {
                        Id = c.ParentCategory.Id,
                        Title = c.ParentCategory.Title,
                        ParentId = c.ParentCategory.ParentId,
                    },
                    Children = c.ChildCategories.Select(ch => new CategoryChildDetailViewModel
                    {
                        Id = ch.Id,
                        Title = ch.Title,
                    }).ToList()
                }).SingleOrDefault();
        }

        public List<CategoryListDetailViewModel> GetCategoryListDetails()
        {
            return _categoryRepository.GetCategoryAndChildrenFlatten(null, true)
                .Select(c => new CategoryListDetailViewModel
                {
                    Id = c.Id,
                    ParentId = c.ParentId,
                    Title = c.Title,
                }).ToList();
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
    }
}
