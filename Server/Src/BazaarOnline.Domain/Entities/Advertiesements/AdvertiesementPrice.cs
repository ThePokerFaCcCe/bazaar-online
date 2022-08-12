using System.ComponentModel.DataAnnotations;

namespace BazaarOnline.Domain.Entities.Advertiesements
{
    public class AdvertiesementPrice
    {
        public int? Value { get; set; }

        public bool IsAgreement { get; set; }

        public AdvertiesementPriceType Type { get; set; }

        public int AdvertiesementId { get; set; }

        #region Relations
        public Advertiesement Advertiesement { get; set; }
        #endregion
    }

    public enum AdvertiesementPriceType
    {
        [Display(Name = "فروشی")]
        ForSell,

        [Display(Name = "اجاره ای")]
        Rentable,

        [Display(Name = "درخواستی")]
        Requested,
    }
}
