using BazaarOnline.Application.Utils.Extentions;
using BazaarOnline.Domain.Entities.Advertiesements;

namespace BazaarOnline.Application.ViewModels.Advertiesements
{
    public class AdvertiesementPriceDetailViewModel
    {
        public long? Value { get; set; }

        public bool IsAgreement { get; set; }

        public AdvertiesementPriceType PriceType { get; set; }

        public string PriceTypeName => PriceType.GetDisplayName();
    }
}
