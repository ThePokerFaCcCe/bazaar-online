using BazaarOnline.Application.DTOs.Locations;
using BazaarOnline.Application.Filters;
using BazaarOnline.Application.Interfaces.Locations;
using BazaarOnline.Application.Utils.Extentions;
using BazaarOnline.Application.ViewModels.Locations;
using BazaarOnline.Domain.Entities.Locations;
using BazaarOnline.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BazaarOnline.Application.Services.Locations
{
    public class LocationService : ILocationService
    {
        private readonly IRepository _repository;

        public LocationService(IRepository repository)
        {
            _repository = repository;
        }

        public List<CityListDetailViewModel> GetCitiesListDetail(CityFilterDTO filterDTO)
        {
            var cities = _repository.GetAll<City>()
                .Include(c => c.Advertiesements)
                .AsQueryable();

            #region Filters
            filterDTO.TrimStrings();

            cities = cities.Filter(filterDTO);
            #endregion

            return cities.Select(c => new CityListDetailViewModel
            {
                AdvertiesementsCount = c.Advertiesements.Count
            }.FillFromObject(c, false))
            .ToList();
        }

        public CityDetailViewModel? GetCityDetail(int id)
        {
            return _repository.GetAll<City>()
                .Where(c => c.Id == id)
                .Include(c => c.Advertiesements)
                .Select(c => new CityDetailViewModel
                {
                    AdvertiesementsCount = c.Advertiesements.Count
                }.FillFromObject(c, false))
                .SingleOrDefault();

        }

        public string? GetCityISOCode(int id)
        {
            return _repository.GetAll<City>()
                .Where(c => c.Id == id)
                .Select(c => c.ISO3166)
                .SingleOrDefault();
        }

        public bool IsCityExists(int id)
        {
            return _repository.GetAll<City>().Any(c => c.Id == id);
        }
    }
}
