using BazaarOnline.Application.Filters.Generic.Attributes;
using BazaarOnline.Domain.Entities.Features;

namespace BazaarOnline.Application.DTOs.Features
{
    public class FeatureFilterDTO
    {
        [Filter(FilterTypeEnum.ModelContainsThis)]
        public string? Title { get; set; }

        [Filter(FilterTypeEnum.Equals)]
        public FeatureTypeEnum? FeatureType { get; set; }
    }
}
