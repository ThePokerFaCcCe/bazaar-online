using BazaarOnline.Domain.Entities.Features;

namespace BazaarOnline.Domain.Entities.Categories
{
    public class CategoryFeature
    {
        public int CategoryId { get; set; }

        public int FeatureId { get; set; }

        #region Relations

        public Category Category { get; set; }
        public Feature Feature { get; set; }

        #endregion
    }
}
