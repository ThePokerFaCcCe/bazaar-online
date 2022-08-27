namespace BazaarOnline.Application.ViewModels.Advertiesements.Management
{
    public class AdvertiesementManagementDetailViewModel
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

        public AdvertiesementContactDetailViewModel Contact { get; set; }

        public DateTime CreateDate { get; set; }

        public AdvertiesementCategoryDetailViewModel Category { get; set; }

        public AdvertiesementCityDetailViewModel City { get; set; }

        public AdvertiesementPriceDetailViewModel Price { get; set; }

        public IEnumerable<AdvertiesementFeatureValueDetailViewModel> FeatureValues { get; set; }

        public IEnumerable<AdvertiesementPictureDetailViewModel> Pictures { get; set; }
    }

}
