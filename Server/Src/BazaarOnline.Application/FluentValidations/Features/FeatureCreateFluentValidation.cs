using BazaarOnline.Application.DTOs.Features;
using BazaarOnline.Domain.Entities.Features;
using FluentValidation;

namespace BazaarOnline.Application.FluentValidations.Features
{
    public class FeatureCreateFluentValidation : AbstractValidator<FeatureCreateDTO>
    {
        public FeatureCreateFluentValidation()
        {
            When(v => v.FeatureType == FeatureTypeEnum.Enum, () =>
            {
                RuleFor(v => v.FeatureType)
                    .Must((v, ft) => v.FeatureEnum != null && v.FeatureInteger == null)
                    .WithMessage("فقط مقدار گزینه انتخاب شده را وارد کنید")
                    .DependentRules(() =>
                    {
                        RuleFor(v => v.FeatureEnum.FeatureEnumValues)
                        .Must(fev => fev.Count > 0)
                        .WithMessage("باید حداقل یک انتخاب وارد کنید");
                    });
            });
            When(v => v.FeatureType == FeatureTypeEnum.Integer, () =>
            {
                RuleFor(v => v.FeatureType)
                .Must((v, ft) => v.FeatureInteger != null && v.FeatureEnum == null)
                .WithMessage("فقط مقدار گزینه انتخاب شده را وارد کنید")
                .DependentRules(() =>
                {
                    RuleFor(v => v.FeatureInteger.MaximumValue)
                        .Must((v, max) => max > v.FeatureInteger.MinimumValue)
                        .WithMessage("مقدار بزرگتری وارد کنید");

                    RuleFor(v => v.FeatureInteger.MinimumValue)
                        .Must((v, min) => min < v.FeatureInteger.MaximumValue)
                        .WithMessage("مقدار کوچکتری وارد کنید");
                });
            });
        }
    }
}
