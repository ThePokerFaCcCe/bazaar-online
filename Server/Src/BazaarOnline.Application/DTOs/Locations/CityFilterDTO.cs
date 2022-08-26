using BazaarOnline.Application.Filters.Generic.Attributes;
using BazaarOnline.Domain.Entities.Locations;

namespace BazaarOnline.Application.DTOs.Locations
{
    public class CityFilterDTO
    {
        [Filter(FilterTypeEnum.ModelContainsThis)]
        public string? Name { get; set; }

        [Order(nameof(City.Name))]
        [Order(nameof(City.Advertiesements), Property = $"{nameof(City.Advertiesements)}.{nameof(City.Advertiesements.Count)}")]
        public string? OrderBy { get; set; } = nameof(City.Name);
    }
}
