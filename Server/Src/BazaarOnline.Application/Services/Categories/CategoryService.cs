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
        private readonly IRepository _repository;

        public CategoryService(IRepository repository)
        {
            _repository = repository;
        }

        public Category CreateCategory(CategoryCreateDTO createDTO)
        {
            createDTO.TrimStrings();

            var category = new Category();
            category.FillFromObject(createDTO);
            category.ChildCategories = createDTO.Children.Select(
                c => new Category
                {
                    Title = c.Title
                }
            ).ToList();

            _repository.Add<Category>(category);
            _repository.Save();

            return category;
        }

        public void DeleteCategory(Category category)
        {
            _repository.RemoveRange<Category>(
                GetCategoryAndChildrenFlatten(category.Id, true)
            );
            _repository.Save();
        }

        public Category? FindCategory(int id, bool includeChildren = false)
        {
            if (!includeChildren)
                return _repository.Get<Category>(id);

            return _repository.GetAll<Category>()
                .Include(c => c.ChildCategories)
                .SingleOrDefault(c => c.Id == id);
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
            return _repository.GetAll<Category>()
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
            return _repository.GetAll<Category>()
                .Any(c => c.Id == id);
        }

        public void UpdateCategory(Category category, CategoryUpdateDTO updateDTO)
        {
            category.FillFromObject(updateDTO);

            _repository.Update<Category>(category);
            _repository.Save();
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

        public void UpdateCategoryFeatures(Category category, CategoryFeatureAddDTO addDTO)
        {

            var oldFeatures = _repository.GetAll<CategoryFeature>()
                .Where(cf => cf.CategoryId == category.Id).ToList();
            var oldFeatureIds = oldFeatures.Select(cf => cf.FeatureId);

            var newFeatures = addDTO.Features.Except(oldFeatureIds);
            var removedFeatures = oldFeatureIds.Except(addDTO.Features);

            _repository.AddRange<CategoryFeature>(
                newFeatures.Select(f => new CategoryFeature
                {
                    CategoryId = category.Id,
                    FeatureId = f
                })
            );
            _repository.RemoveRange<CategoryFeature>(
                oldFeatures
                    .Where(cf => removedFeatures.Contains(cf.FeatureId))
            );
            _repository.Save();
        }

        public List<FeatureDetailViewModel> GetCategoryFeatureDetails(Category category)
        {
            return _GetFeatureDetails(
                _repository.GetAll<CategoryFeature>()
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
            var hierarchy = GetCategoryAndParentFlatten(category.Id, includeSelf: true)
                .Select(c => c.Id);

            return _GetFeatureDetails(
                _repository.GetAll<CategoryFeature>()
                    .Where(cf => hierarchy.Contains(cf.CategoryId)));

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

        public IEnumerable<Feature> GetCategoryFeaturesHierarchy(Category category)
        {
            var hierarchy = GetCategoryAndParentFlatten(category.Id, includeSelf: true)
                .Select(c => c.Id);

            return _repository.GetAll<CategoryFeature>()
                    .Where(cf => hierarchy.Contains(cf.CategoryId))
                    .Include(cf => cf.Feature)
                        .ThenInclude(f => f.FeatureEnum)
                        .ThenInclude(fe => fe.FeatureEnumValues)
                    .Include(cf => cf.Feature)
                        .ThenInclude(f => f.FeatureInteger)
                    .Select(cf => cf.Feature);
        }
    }
}
