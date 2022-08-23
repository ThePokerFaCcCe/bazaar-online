using BazaarOnline.Domain.Entities.Categories;
using BazaarOnline.Domain.Entities.Locations;
using BazaarOnline.Domain.Entities.Users;

namespace BazaarOnline.Domain.Entities.Advertiesements
{
    public class Advertiesement
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string? Address { get; set; }

        public double Longitude { get; set; }

        public double Latitude { get; set; }

        public string? DeniedByAdminReason { get; set; }

        public bool IsDeniedByAdmin { get; set; }

        public string? DeletedByAdminReason { get; set; }

        public bool IsDeletedByAdmin { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsAccepted { get; set; }

        public bool IsChatOnly { get; set; }

        public DateTime CreateDate { get; set; }

        public int CategoryId { get; set; }

        public int CityId { get; set; }

        public int UserId { get; set; }


        #region Relations

        public Category Category { get; set; }

        public City City { get; set; }

        public User User { get; set; }

        public AdvertiesementPrice AdvertiesementPrice { get; set; }

        public List<AdvertiesementFeatureValue> AdvertiesementFeatureValues { get; set; }

        public List<AdvertiesementPicture> AdvertiesementPictures { get; set; }

        #endregion

    }
}
