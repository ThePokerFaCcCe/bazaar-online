using BazaarOnline.Application.DTOs.Locations;
using BazaarOnline.Application.Interfaces.Locations;
using BazaarOnline.Application.Utils.Extentions;
using BazaarOnline.Application.ViewModels.Locations;
using BazaarOnline.Domain.Entities.Locations;
using BazaarOnline.Domain.Interfaces.Locations;

namespace BazaarOnline.Application.Services.Locations
{
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository _locationRepository;

        public LocationService(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public List<CityListDetailViewModel> GetCitiesListDetail(CityFilterDTO filterDTO)
        {
            var cities = _locationRepository.GetCities();

            #region Filters
            filterDTO.TrimStrings();

            if (!string.IsNullOrEmpty(filterDTO.Name))
                cities = cities.Where(c => c.Name.Contains(filterDTO.Name.ToLower()));

            #endregion

            return cities.Select(c =>
                    ModelHelper.CreateAndFillFromObject
                        <CityListDetailViewModel, City>(c, false)
                ).ToList();
        }

        public CityDetailViewModel? GetCityDetail(int id)
        {
            return _locationRepository.GetCities()
                .Where(c => c.Id == id)
                .Select(c => new CityDetailViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                }).SingleOrDefault();

        }
    }
}
