using BazaarOnline.Application.DTOs.CategoryDTOs;
using BazaarOnline.Application.Interfaces.Categories;
using BazaarOnline.Application.Utils.Extentions;
using BazaarOnline.Application.ViewModels.Categories;
using BazaarOnline.Application.ViewModels.Features;
using BazaarOnline.Domain.Entities.Categories;
using BazaarOnline.Domain.Entities.Features;
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

        public void UpdateCategoryFeatures(Category category, CategoryFeatureAddDTO addDTO)
        {

            var oldFeatures = _categoryRepository.GetCategoryFeatures(category.Id).ToList();
            var oldFeatureIds = oldFeatures.Select(cf => cf.FeatureId);

            var newFeatures = addDTO.Features.Except(oldFeatureIds);
            var removedFeatures = oldFeatureIds.Except(addDTO.Features);

            _categoryRepository.AddCategoryFeatureRange(
                newFeatures.Select(f => new CategoryFeature
                {
                    CategoryId = category.Id,
                    FeatureId = f
                }).ToArray()
            );
            _categoryRepository.DeleteCategoryFeatureRange(
                oldFeatures
                    .Where(cf => removedFeatures.Contains(cf.FeatureId))
                    .ToArray()
            );
            _categoryRepository.Save();
        }

        public List<FeatureDetailViewModel> GetCategoryFeatureDetails(Category category)
        {
            return _GetFeatureDetails(_categoryRepository.GetCategoryFeatures(category.Id));
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
            var allCategories = _categoryRepository.GetCategories().AsEnumerable();


            var ccategory = allCategories.Single(c => c.Id == category.Id);
            var hierarchy = new List<int> { ccategory.Id };

            while (ccategory.ParentId != null)
            {
                ccategory = allCategories.Single(c => c.Id == ccategory.ParentId);
                hierarchy.Add(ccategory.Id);
            }

            return _GetFeatureDetails(
                _categoryRepository.GetCategoryFeatures(hierarchy.ToArray())
            );

        }
    }
}
