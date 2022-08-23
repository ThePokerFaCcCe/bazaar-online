using BazaarOnline.Application.Filters.Generic.Attributes;
using BazaarOnline.Domain.Entities.Advertiesements;

namespace BazaarOnline.Application.DTOs.Advertiesements.AdvertiesementFilterDTOs
{
    public class AdvertiesementGlobalFilterDTO
    {
        [Filter(FilterTypeEnum.ModelContainsThis)]
        public string? Title { get; set; }

        [Filter(FilterTypeEnum.Equals)]
        public int? Category { get; set; }

        [Filter(FilterTypeEnum.ThisContainsModel, ModelPropertyName = nameof(Advertiesement.City))]
        public IEnumerable<int>? Cities { get; set; }

        [Filter(FilterTypeEnum.Equals, ModelPropertyName = $"{nameof(Advertiesement.AdvertiesementPrice)}.{nameof(Advertiesement.AdvertiesementPrice.Type)}")]
        public AdvertiesementPriceType? PriceType { get; set; }

        [Filter(FilterTypeEnum.ModelGreaterThanEqualThis, ModelPropertyName = $"{nameof(Advertiesement.AdvertiesementPrice)}.{nameof(Advertiesement.AdvertiesementPrice.Value)}")]
        public long? StartPrice { get; set; }

        [Filter(FilterTypeEnum.ModelSmallerThanEqualThis, ModelPropertyName = $"{nameof(Advertiesement.AdvertiesementPrice)}.{nameof(Advertiesement.AdvertiesementPrice.Value)}")]
        public long? EndPrice { get; set; }
    }
}
