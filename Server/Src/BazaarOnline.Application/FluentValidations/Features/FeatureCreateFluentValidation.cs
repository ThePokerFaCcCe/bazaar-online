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
                RuleFor(v => v.FeatureInteger)
                    .Null()
                    .WithMessage("نباید این قسمت را وارد کنید");

                RuleFor(v => v.FeatureEnum)
                    .NotNull()
                    .WithMessage("وارد کردن این قسمت الزامیست")
                    .DependentRules(() =>
                    {
                        RuleFor(v => v.FeatureEnum.FeatureEnumValues)
                        .Must(fev => fev.Count > 0)
                        .WithMessage("باید حداقل یک انتخاب وارد کنید");
                    });
            });
            When(v => v.FeatureType == FeatureTypeEnum.Integer, () =>
            {
                RuleFor(v => v.FeatureEnum)
                    .Null()
                    .WithMessage("نباید این قسمت را وارد کنید");

                RuleFor(v => v.FeatureInteger)
                    .NotNull()
                    .WithMessage("وارد کردن این قسمت الزامیست")
                    .DependentRules(() =>
                    {
                        RuleFor(v => v.FeatureInteger.MaximumValue)
                            .Must((v, max) => max > v.FeatureInteger.MinimumValue)
                            .WithMessage("مقدار بزرگتری وارد کنید");
                    });
            });
        }
    }
}
