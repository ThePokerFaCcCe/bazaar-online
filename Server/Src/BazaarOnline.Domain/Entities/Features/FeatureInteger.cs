namespace BazaarOnline.Domain.Entities.Features
{
    public class FeatureInteger
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public long MinimumValue { get; set; }

        public long MaximumValue { get; set; }


        #region Relations

        public List<Feature> Features { get; set; }

        #endregion
    }
}
