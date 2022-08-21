using BazaarOnline.Domain.Entities.Advertiesements;

namespace BazaarOnline.Domain.Entities.Locations
{
    public class City
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ISO3166 { get; set; }

        #region Relations
        public List<Advertiesement> Advertiesements { get; set; }
        #endregion
    }
}
