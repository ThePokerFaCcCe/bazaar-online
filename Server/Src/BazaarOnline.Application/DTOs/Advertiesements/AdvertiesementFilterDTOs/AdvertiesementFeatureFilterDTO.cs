namespace BazaarOnline.Application.DTOs.Advertiesements.AdvertiesementFilterDTOs
{
    public class AdvertiesementFeatureFilterDTO
    {
        public int FeatureId { get; set; }
        public string FeatureValue { get; set; }
        public FeatureFilterTypeEnum FilterTypeEnum { get; set; }
    }

    public enum FeatureFilterTypeEnum
    {
        /// <summary>
        /// This value should equal to feature value.
        /// </summary>
        Equals,

        /// <summary>
        /// This value should greater than or equal to feature value.
        /// </summary>
        GreaterThanEqual,

        /// <summary>
        /// This value should less than or equal to feature value.
        /// </summary>
        LessThanEqual,

    }
}
