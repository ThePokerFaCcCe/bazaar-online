using BazaarOnline.Domain.Entities.Features;

namespace BazaarOnline.Domain.Entities.Advertiesements
{
    public class AdvertiesementFeatureValue
    {
        public int FeatureId { get; set; }
        public int AdvertiesementId { get; set; }
        public string? Value { get; set; }


        #region Relations

        public Feature Feature { get; set; }
        public Advertiesement Advertiesement { get; set; }

        #endregion
    }
}
