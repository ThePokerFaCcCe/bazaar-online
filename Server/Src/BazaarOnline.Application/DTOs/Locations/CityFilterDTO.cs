using BazaarOnline.Application.Filters.Generic.Attributes;

namespace BazaarOnline.Application.DTOs.Locations
{
    public class CityFilterDTO
    {
        [Filter(FilterTypeEnum.ModelContainsThis)]
        public string? Name { get; set; } = string.Empty;
    }
}
