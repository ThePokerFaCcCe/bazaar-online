using BazaarOnline.Application.DTOs.Locations;
using BazaarOnline.Application.Interfaces.Locations;
using BazaarOnline.Application.Utils.Extentions;
using BazaarOnline.Application.ViewModels.Locations;
using BazaarOnline.Domain.Entities.Locations;
using BazaarOnline.Domain.Interfaces;

namespace BazaarOnline.Application.Services.Locations
{
    public class LocationService : ILocationService
    {
        private readonly IRepositories _repositories;

        public LocationService(IRepositories repositories)
        {
            _repositories = repositories;
        }

        public List<CityListDetailViewModel> GetCitiesListDetail(CityFilterDTO filterDTO)
        {
            var cities = _repositories.Cities.GetAll();

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
            return _repositories.Cities.GetAll()
                .Where(c => c.Id == id)
                .Select(c => new CityDetailViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                }).SingleOrDefault();

        }
    }
}
