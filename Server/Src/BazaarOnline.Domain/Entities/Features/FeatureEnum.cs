namespace BazaarOnline.Domain.Entities.Features
{
    public class FeatureEnum
    {
        public int Id { get; set; }

        public string Name { get; set; }

        #region Relations

        public List<FeatureEnumValue> FeatureEnumValues { get; set; }

        public List<Feature> Features { get; set; }

        #endregion
    }

}
