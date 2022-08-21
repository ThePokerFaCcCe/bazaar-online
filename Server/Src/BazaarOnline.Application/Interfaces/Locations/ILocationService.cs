using BazaarOnline.Application.DTOs.Locations;
using BazaarOnline.Application.ViewModels.Locations;

namespace BazaarOnline.Application.Interfaces.Locations
{
    public interface ILocationService
    {
        List<CityListDetailViewModel> GetCitiesListDetail(CityFilterDTO filterDTO);

        CityDetailViewModel? GetCityDetail(int id);

        string? GetCityISOCode(int id);

        bool IsCityExists(int id);
    }
}
