namespace BazaarOnline.Domain.Entities.Features
{
    public class FeatureEnumValue
    {
        public int Id { get; set; }

        public string Value { get; set; }

        public int FeatureEnumId { get; set; }


        #region Relations

        public FeatureEnum FeatureEnum { get; set; }

        #endregion

    }

}
