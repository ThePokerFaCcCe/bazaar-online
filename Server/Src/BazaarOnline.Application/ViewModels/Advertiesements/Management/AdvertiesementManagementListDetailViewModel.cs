namespace BazaarOnline.Application.ViewModels.Advertiesements.Management
{
    public class AdvertiesementManagementListDetailViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string? DeniedByAdminReason { get; set; }

        public bool IsDeniedByAdmin { get; set; }

        public string? DeletedByAdminReason { get; set; }

        public bool IsDeletedByAdmin { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsAccepted { get; set; }

        public DateTime CreateDate { get; set; }

        public AdvertiesementCategoryDetailViewModel Category { get; set; }

        public AdvertiesementCityDetailViewModel City { get; set; }

        public AdvertiesementPriceDetailViewModel Price { get; set; }

        public AdvertiesementPictureDetailViewModel? Picture { get; set; }

    }
}
