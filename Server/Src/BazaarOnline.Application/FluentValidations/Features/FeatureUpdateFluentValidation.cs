using BazaarOnline.Application.DTOs.Features;
using FluentValidation;

namespace BazaarOnline.Application.FluentValidations.Features
{
    public class FeatureUpdateFluentValidation : AbstractValidator<FeatureIntegerUpdateDTO>
    {
        public FeatureUpdateFluentValidation()
        {
            RuleFor(v => v.MaximumValue)
                .Must((v, max) => max > v.MinimumValue)
                .WithMessage("مقدار بزرگتری وارد کنید");
        }
    }
}
