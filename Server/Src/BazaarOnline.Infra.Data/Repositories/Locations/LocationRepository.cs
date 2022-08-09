using BazaarOnline.Domain.Entities.Locations;
using BazaarOnline.Domain.Interfaces.Locations;
using BazaarOnline.Infra.Data.Contexts;
using BazaarOnline.Infra.Data.Seeds.DefaultDatas;

namespace BazaarOnline.Infra.Data.Repositories.Locations
{
    public class LocationRepository : ILocationRepository
    {
        private readonly BazaarDbContext _context;

        public LocationRepository(BazaarDbContext context)
        {
            _context = context;
        }

        public City? FindCity(int id)
        {
            return _context.Cities.Find(id);
        }

        public IQueryable<City> GetCities()
        {
            return _context.Cities.AsQueryable();
        }
    }
}
