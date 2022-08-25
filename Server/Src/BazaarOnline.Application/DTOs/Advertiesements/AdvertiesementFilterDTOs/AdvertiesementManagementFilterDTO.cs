using BazaarOnline.Application.Filters.Generic.Attributes;
using BazaarOnline.Domain.Entities.Advertiesements;

namespace BazaarOnline.Application.DTOs.Advertiesements.AdvertiesementFilterDTOs
{
    public class AdvertiesementManagementFilterDTO
    {
        [Filter(FilterTypeEnum.Equals)]
        public bool? IsDeleted { get; set; }

        [Filter(FilterTypeEnum.Equals)]
        public bool? IsAccepted { get; set; }

        [Filter(FilterTypeEnum.Equals, ModelPropertyName = nameof(Advertiesement.CategoryId))]
        public int? Category { get; set; }

        [Filter(FilterTypeEnum.ThisContainsModel, ModelPropertyName = nameof(Advertiesement.CityId))]
        public List<int>? Cities { get; set; }

        [Filter(FilterTypeEnum.Equals, ModelPropertyName = $"{nameof(Advertiesement.AdvertiesementPrice)}.{nameof(Advertiesement.AdvertiesementPrice.Type)}")]
        public AdvertiesementPriceType? PriceType { get; set; }

        [Filter(FilterTypeEnum.ModelGreaterThanEqualThis, ModelPropertyName = $"{nameof(Advertiesement.AdvertiesementPrice)}.{nameof(Advertiesement.AdvertiesementPrice.Value)}")]
        public long? StartPrice { get; set; }

        [Filter(FilterTypeEnum.ModelSmallerThanEqualThis, ModelPropertyName = $"{nameof(Advertiesement.AdvertiesementPrice)}.{nameof(Advertiesement.AdvertiesementPrice.Value)}")]
        public long? EndPrice { get; set; }

        [Order(nameof(Advertiesement.Title))]
        [Order(nameof(Advertiesement.CreateDate))]
        [Order("Price", Property = $"{nameof(Advertiesement.AdvertiesementPrice)}.{nameof(Advertiesement.AdvertiesementPrice.Value)}")]
        [Order(nameof(Advertiesement.IsAccepted))]
        [Order(nameof(Advertiesement.IsDeniedByAdmin))]
        [Order(nameof(Advertiesement.IsDeleted))]
        [Order(nameof(Advertiesement.IsDeletedByAdmin))]
        public string? OrderBy { get; set; }
    }
}
