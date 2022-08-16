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
        private readonly IRepository _repository;

        public LocationService(IRepository repository)
        {
            _repository = repository;
        }

        public List<CityListDetailViewModel> GetCitiesListDetail(CityFilterDTO filterDTO)
        {
            var cities = _repository.GetAll<City>();

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
            return _repository.GetAll<City>()
                .Where(c => c.Id == id)
                .Select(c => new CityDetailViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                }).SingleOrDefault();

        }
    }
}
