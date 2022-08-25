using BazaarOnline.Application.Filters.Generic.Attributes;
using BazaarOnline.Domain.Entities.Locations;

namespace BazaarOnline.Application.DTOs.Locations
{
    public class CityFilterDTO
    {
        [Filter(FilterTypeEnum.ModelContainsThis)]
        public string? Name { get; set; } = string.Empty;

        [Order(nameof(City.Name))]
        public string? OrderBy { get; set; } = nameof(City.Name);
    }
}
