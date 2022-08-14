namespace BazaarOnline.Domain.Entities.Features
{
    public class FeatureInteger
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public long MinimumValue { get; set; }

        public long MaximumValue { get; set; }

        public int FeatureId { get; set; }

        #region Relations

        public Feature Feature { get; set; }

        #endregion
    }
}
