using BazaarOnline.Application.ViewModels.Features;

namespace BazaarOnline.Application.ViewModels.Advertiesements
{
    public class AdvertiesementDetailViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string? Address { get; set; }

        public double Longitude { get; set; }

        public double Latitude { get; set; }

        public bool IsChatOnly { get; set; }

        public DateTime CreateDate { get; set; }

        public AdvertiesementCategoryDetailViewModel Category { get; set; }

        public AdvertiesementCityDetailViewModel City { get; set; }

        public AdvertiesementPriceDetailViewModel Price { get; set; }

        public IEnumerable<AdvertiesementFeatureValueDetailViewModel> FeatureValues { get; set; }

        public IEnumerable<AdvertiesementPictureDetailViewModel> Pictures { get; set; }
    }

    public class AdvertiesementFeatureValueDetailViewModel
    {
        public string Title { get; set; }

        public string? Value { get; set; }
    }
}
