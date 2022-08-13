using BazaarOnline.Application.Utils.Extentions;
using BazaarOnline.Domain.Entities.Features;

namespace BazaarOnline.Application.ViewModels.Features
{
    public class FeatureListDetailViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public FeatureTypeEnum FeatureType { get; set; }

        public string? FeatureTypeName => FeatureType.GetDisplayName();
    }
}
