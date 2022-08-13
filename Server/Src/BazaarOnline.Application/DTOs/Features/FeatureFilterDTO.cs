using BazaarOnline.Domain.Entities.Features;

namespace BazaarOnline.Application.DTOs.Features
{
    public class FeatureFilterDTO
    {
        public string? Title { get; set; }
        public FeatureTypeEnum? FeatureType { get; set; }
    }
}
