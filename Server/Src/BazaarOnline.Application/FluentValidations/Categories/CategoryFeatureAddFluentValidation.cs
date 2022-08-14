using BazaarOnline.Application.DTOs.CategoryDTOs;
using BazaarOnline.Application.Interfaces.Features;
using FluentValidation;

namespace BazaarOnline.Application.FluentValidations.Categories
{
    public class CategoryFeatureAddFluentValidation : AbstractValidator<CategoryFeatureAddDTO>
    {
        public CategoryFeatureAddFluentValidation(IFeatureService featureService)
        {
            RuleFor(v => v.Features)
                .NotEmpty()
                .WithMessage("حداقل یک مورد وارد کنید")
                .DependentRules(() =>
                {
                    RuleFor(v => v.Features)
                        .Must(selectedFeatures =>
                        {
                            var featureIds = featureService.GetFeatureIds();
                            var invalidFeatures = selectedFeatures.Except(featureIds);

                            return !invalidFeatures.Any();
                        }).WithMessage("تمام موارد معتبر نیستند");
                });
        }
    }
}
