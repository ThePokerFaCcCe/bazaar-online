using BazaarOnline.Application.DTOs.CategoryDTOs;
using BazaarOnline.Application.Interfaces.Categories;
using BazaarOnline.Application.Utils.Extentions;
using BazaarOnline.Application.ViewModels.Categories;
using BazaarOnline.Application.ViewModels.Features;
using BazaarOnline.Domain.Entities.Categories;
using BazaarOnline.Domain.Entities.Features;
using BazaarOnline.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BazaarOnline.Application.Services.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepositories _repositories;

        public CategoryService(IRepositories repositories)
        {
            _repositories = repositories;
        }

        public Category CreateCategory(CategoryCreateDTO createDTO)
        {
            createDTO.TrimStrings();

            var category = new Category();
            category.FillFromObject(createDTO);

            _repositories.Categories.Add(category);
            _repositories.Categories.Save();

            return category;
        }

        public void DeleteCategory(Category category)
        {
            _repositories.Categories.RemoveRange(
                GetCategoryAndChildrenFlatten(category.Id, true)
            );
            _repositories.Categories.Save();
        }

        public Category? FindCategory(int id)
        {
            return _repositories.Categories.Get(id);
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
            return _repositories.Categories.GetAll()
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
            return _repositories.Categories.GetAll()
                .Any(c => c.Id == id);
        }

        public void UpdateCategory(Category category, CategoryUpdateDTO updateDTO)
        {
            category.FillFromObject(updateDTO);

            _repositories.Categories.Update(category);
            _repositories.Categories.Save();
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
            if (allCategories == null) allCategories = _repositories.Categories.GetAll().ToList();
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

        public void UpdateCategoryFeatures(Category category, CategoryFeatureAddDTO addDTO)
        {

            var oldFeatures = _repositories.CategoryFeatures.GetAll()
                .Where(cf => cf.CategoryId == category.Id).ToList();
            var oldFeatureIds = oldFeatures.Select(cf => cf.FeatureId);

            var newFeatures = addDTO.Features.Except(oldFeatureIds);
            var removedFeatures = oldFeatureIds.Except(addDTO.Features);

            _repositories.CategoryFeatures.AddRange(
                newFeatures.Select(f => new CategoryFeature
                {
                    CategoryId = category.Id,
                    FeatureId = f
                })
            );
            _repositories.CategoryFeatures.RemoveRange(
                oldFeatures
                    .Where(cf => removedFeatures.Contains(cf.FeatureId))
            );
            _repositories.CategoryFeatures.Save();
        }

        public List<FeatureDetailViewModel> GetCategoryFeatureDetails(Category category)
        {
            return _GetFeatureDetails(
                _repositories.CategoryFeatures.GetAll()
                    .Where(cf => cf.CategoryId == category.Id));
        }

        private List<FeatureDetailViewModel> _GetFeatureDetails(IQueryable<CategoryFeature> categoryFeatures)
        {
            return categoryFeatures
                .Include(cf => cf.Feature)
                .ThenInclude(f => f.FeatureEnum)
                .ThenInclude(fe => fe.FeatureEnumValues)
                .Include(cf => cf.Feature)
                .ThenInclude(cf => cf.FeatureInteger)
                .AsEnumerable()
                .Select(cf =>
                {
                    var model = ModelHelper.CreateAndFillFromObject
                        <FeatureDetailViewModel, Feature>(cf.Feature);

                    if (cf.Feature.FeatureEnum != null)
                    {
                        model.Enum = ModelHelper.CreateAndFillFromObject
                            <FeatureDetailEnumDetailViewModel, FeatureEnum>(cf.Feature.FeatureEnum);

                        model.Enum.Values = cf.Feature.FeatureEnum.FeatureEnumValues
                            .Select(fev =>
                                ModelHelper.CreateAndFillFromObject
                                    <FeatureDetailEnumValueDetailViewModel, FeatureEnumValue>(fev))
                            .ToList();
                    }
                    if (cf.Feature.FeatureInteger != null)
                    {
                        model.Integer = ModelHelper.CreateAndFillFromObject
                            <FeatureDetailIntegerDetailViewModel, FeatureInteger>(cf.Feature.FeatureInteger);
                    }

                    return model;
                }).ToList();
        }

        public List<FeatureDetailViewModel> GetCategoryFeatureDetailsHierarchy(Category category)
        {
            var allCategories = _repositories.Categories.GetAll().AsEnumerable();


            var ccategory = allCategories.Single(c => c.Id == category.Id);
            var hierarchy = new List<int> { ccategory.Id };

            while (ccategory.ParentId != null)
            {
                ccategory = allCategories.Single(c => c.Id == ccategory.ParentId);
                hierarchy.Add(ccategory.Id);
            }

            return _GetFeatureDetails(
                _repositories.CategoryFeatures.GetAll()
                    .Where(cf => hierarchy.Contains(cf.CategoryId)));

        }
    }
}
