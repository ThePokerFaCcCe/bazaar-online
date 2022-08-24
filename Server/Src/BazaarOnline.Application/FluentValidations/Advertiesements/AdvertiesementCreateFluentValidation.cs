using BazaarOnline.Application.DTOs.Advertiesements;
using BazaarOnline.Application.Interfaces.Categories;
using BazaarOnline.Application.Interfaces.Locations;
using BazaarOnline.Application.Interfaces.ReverseGeocoding;
using BazaarOnline.Domain.Entities.Categories;
using BazaarOnline.Domain.Entities.Features;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Testing.Application.Validators;

namespace BazaarOnline.Application.FluentValidations.Advertiesements
{
    public class AdvertiesementCreateFluentValidation : AbstractValidator<AdvertiesementCreateDTO>
    {
        private ICategoryService _categoryService;
        public AdvertiesementCreateFluentValidation(ICategoryService categoryService, ILocationService locationService, IReverseGeocodingService _reverseGeocodingService)
        {
            _categoryService = categoryService;

            RuleFor(v => v.CityId)
                .Must(c => locationService.IsCityExists(c))
                .WithMessage("استان معتبر نیست")
            .DependentRules(() =>
            {
                RuleFor(v => v.CityId)
                    .Must((v, cityId) =>
                    {
                        var task = Task.Run(() => _reverseGeocodingService.IsCoordinateInsideProvince(
                            locationService.GetCityISOCode(cityId),
                            v.Latitude,
                            v.Longitude
                        ));
                        task.Wait();
                        return task.Result;
                    })
                    .WithMessage("محدوده مشخص شده در نقشه خارج از استان است");
            });
            RuleFor(v => v.AdvertiesementPictures)
                .Must(pics => pics.Count() <= 5)
                .WithMessage("حداکثر میتوانید 5 عکس ثبت کنید")
                .When(v => v.AdvertiesementPictures != null)
                .DependentRules(() =>
                {
                    RuleForEach(v => v.AdvertiesementPictures)
                        .Must(ap => ap.IsValidImage())
                        .WithMessage("عکس معتبر نیست")
                        .Must(ap => ap.IsSizeSmallerThan(1000))
                        .WithMessage("حجم عکس بیشتر از 1000 کیلوبایت است")
                        .Must(ap => ap.HasValidExtension(new[] { ".jpg", ".png" }))
                        .WithMessage("فرمت عکس باید jpg یا png باشد");
                });

            RuleFor(v => v.AdvertiesementPrice)
            .ChildRules(ap =>
            {
                ap.RuleFor(ap => ap.Value)
                    .Null()
                    .When(ap => ap.IsAgreement, ApplyConditionTo.CurrentValidator)
                    .WithMessage("در حالت توافقی نباید مبلغی وارد کنید")
                    .NotNull()
                    .When(ap => !ap.IsAgreement, ApplyConditionTo.CurrentValidator)
                    .WithMessage("در حالت غیر توافقی باید مبلغ را وارد کنید");
            });

            RuleFor(v => v.CategoryId)
                .Must(c => GetCategory(c) != null)
                .WithMessage("دسته بندی یافت نشد")
            .DependentRules(() =>
            {
                RuleFor(v => v.CategoryId)
                    .Must(c => GetCategory(c).ChildCategories.Count() == 0)
                    .WithMessage("شما نمیتوانید در این دسته بندی آگهی ثبت کنید")
                .DependentRules(() =>
                {
                    RuleFor(v => v.AdvertiesementFeatureValues)
                        .Must((v, afs) =>
                        {
                            var allFeatures = GetFeatures(GetCategory(v.CategoryId))
                                .Select(f => f.Id);

                            var enteredFeatures = afs.Select(af => af.FeatureId);

                            return enteredFeatures.Except(allFeatures).Count() == 0;
                        }).WithMessage(v =>
                        {
                            var featureIds = string.Join(',', GetFeatures(GetCategory(v.CategoryId)).Select(f => f.Id));
                            return $"فقط ویژگی های \"{featureIds}\" معتبرند";
                        })

                        .Must((v, afs) =>
                        {
                            var requiredFeatures = GetFeatures(GetCategory(v.CategoryId))
                                .Where(f => f.IsRequired).Select(f => f.Id);

                            var enteredFeatures = afs.Select(af => af.FeatureId);

                            return requiredFeatures.Except(enteredFeatures).Count() == 0;
                        }).WithMessage(v =>
                        {
                            var featureIds = string.Join(',',
                                GetFeatures(GetCategory(v.CategoryId))
                                .Where(f => f.IsRequired)
                                .Select(f => f.Id));
                            return $"وارد کردن ویژگی های \"{featureIds}\" اجباریست";
                        })

                    .DependentRules(() =>
                    {
                        #region Integers

                        RuleForEach(v => v.AdvertiesementFeatureValues)
                            .Where(af =>
                                _features
                                .Where(f => f.FeatureType == FeatureTypeEnum.Integer)
                                .Select(f => f.Id).Contains(af.FeatureId))
                            .ChildRules(af =>
                            {
                                af.RuleFor(af => af.Value)
                                    .Must(v => Int64.TryParse(v, out long value))
                                    .WithMessage("باید عدد وارد کنید")
                                .DependentRules(() =>
                                {
                                    af.RuleFor(af => af.Value)

                                        .Must((af, v) =>
                                           Int64.Parse(v) <= GetFeature(af.FeatureId).FeatureInteger.MaximumValue)
                                        .WithMessage(af => $"مقدار باید کوچکتر از {GetFeature(af.FeatureId).FeatureInteger.MaximumValue} باشد")

                                        .Must((af, v) =>
                                           Int64.Parse(v) >= GetFeature(af.FeatureId).FeatureInteger.MinimumValue)
                                        .WithMessage(af => $"مقدار باید بزرگتر از {GetFeature(af.FeatureId).FeatureInteger.MinimumValue} باشد");
                                });
                            });

                        #endregion

                        #region Enums
                        RuleForEach(v => v.AdvertiesementFeatureValues)
                            .Where(af =>
                                _features
                                .Where(f => f.FeatureType == FeatureTypeEnum.Enum)
                                .Select(f => f.Id).Contains(af.FeatureId))
                            .ChildRules(af =>
                            {
                                af.RuleFor(af => af.Value)
                                    .Must((af, v) =>
                                        GetFeature(af.FeatureId).FeatureEnum
                                            .FeatureEnumValues
                                            .Any(fev => fev.Value == v)
                                        )
                                    .WithMessage(af =>
                                    {
                                        var enums = string.Join(',',
                                            GetFeature(af.FeatureId).FeatureEnum
                                            .FeatureEnumValues
                                            .Select(fev => fev.Value));
                                        return $"مقدار وارد شده معتبر نیست. \"{enums}\"";
                                    });
                            });
                        #endregion
                    });
                });
            });
        }


        private Category? _category;
        private Category? GetCategory(int id)
        {
            if (_category == null)
                _category = _categoryService.FindCategory(id, true);

            return _category;
        }

        private IEnumerable<Feature>? _features;
        private IEnumerable<Feature> GetFeatures(Category category)
        {
            if (_features == null)
            {
                _features = _categoryService.GetCategoryFeaturesHierarchy(category);
            }
            return _features;
        }

        private Feature GetFeature(int id) => _features.First(f => f.Id == id);
    }

    public class AdvertiesementFeatureIntegerValidator : AbstractValidator<AdvertiesementFeatureValueCreateDTO>
    {
        public AdvertiesementFeatureIntegerValidator()
        {

        }
    }
}
