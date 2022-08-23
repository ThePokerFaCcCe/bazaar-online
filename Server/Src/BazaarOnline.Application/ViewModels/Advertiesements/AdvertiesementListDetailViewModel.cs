namespace BazaarOnline.Application.ViewModels.Advertiesements
{
    public class AdvertiesementListDetailViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime CreateDate { get; set; }

        public AdvertiesementCategoryDetailViewModel Category { get; set; }

        public AdvertiesementCityDetailViewModel City { get; set; }

        public AdvertiesementPriceDetailViewModel Price { get; set; }

        public AdvertiesementPictureDetailViewModel? Picture { get; set; }
    }
}
