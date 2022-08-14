namespace BazaarOnline.Domain.Entities.Features
{
    public class FeatureEnum
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int FeatureId { get; set; }

        #region Relations

        public List<FeatureEnumValue> FeatureEnumValues { get; set; }

        public Feature Feature { get; set; }

        #endregion
    }

}
