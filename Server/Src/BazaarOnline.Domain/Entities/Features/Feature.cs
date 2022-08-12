using System.ComponentModel.DataAnnotations;
using BazaarOnline.Domain.Entities.Advertiesements;
using BazaarOnline.Domain.Entities.Categories;

namespace BazaarOnline.Domain.Entities.Features
{
    public class Feature
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public FeatureTypeEnum FeatureType { get; set; }

        public bool IsRequired { get; set; }

        public int? FeatureEnumId { get; set; }
        public int? FeatureIntegerId { get; set; }

        #region Relations

        public FeatureEnum? FeatureEnum { get; set; }
        public FeatureInteger? FeatureInteger { get; set; }

        public List<AdvertiesementFeatureValue> AdvertiesementFeatureValues { get; set; }
        public List<CategoryFeature> CategoryFeatures { get; set; }

        #endregion
    }

    public enum FeatureTypeEnum
    {
        [Display(Name = "عدد")]
        Integer,

        [Display(Name = "انتخابی")]
        Enum,
    }

}
