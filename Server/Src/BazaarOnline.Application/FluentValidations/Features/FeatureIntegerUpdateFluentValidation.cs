using BazaarOnline.Application.DTOs.Features;
using FluentValidation;

namespace BazaarOnline.Application.FluentValidations.Features
{
    public class FeatureIntegerUpdateFluentValidation : AbstractValidator<FeatureIntegerUpdateDTO>
    {
        public FeatureIntegerUpdateFluentValidation()
        {
            RuleFor(v => v.MaximumValue)
                .Must((v, max) => max > v.MinimumValue)
                .WithMessage("مقدار بزرگتری وارد کنید");
        }
    }
}
