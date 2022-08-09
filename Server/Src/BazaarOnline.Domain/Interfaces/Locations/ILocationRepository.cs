using BazaarOnline.Domain.Entities.Locations;

namespace BazaarOnline.Domain.Interfaces.Locations
{
    public interface ILocationRepository
    {
        IQueryable<City> GetCities();

        City? FindCity(int id);
    }
}
