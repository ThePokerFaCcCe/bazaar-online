using BazaarOnline.Application.Utils.Extentions;
using BazaarOnline.Domain.Entities.Features;

namespace BazaarOnline.Application.ViewModels.Features
{
    public class FeatureDetailViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public bool IsRequired { get; set; }

        public FeatureTypeEnum FeatureType { get; set; }

        public string? FeatureTypeName => FeatureType.GetDisplayName();

        public FeatureDetailEnumDetailViewModel? Enum { get; set; }

        public FeatureDetailIntegerDetailViewModel? Integer { get; set; }

    }

    public class FeatureDetailEnumDetailViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<FeatureDetailEnumValueDetailViewModel> Values { get; set; }
    }

    public class FeatureDetailEnumValueDetailViewModel
    {
        public int Id { get; set; }

        public string Value { get; set; }
    }

    public class FeatureDetailIntegerDetailViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public long MinimumValue { get; set; }

        public long MaximumValue { get; set; }
    }
}
