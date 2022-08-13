using BazaarOnline.Domain.Entities.Advertiesements;
using BazaarOnline.Domain.Interfaces.Advertiesements;
using BazaarOnline.Infra.Data.Contexts;

namespace BazaarOnline.Infra.Data.Repositories.Advertiesements
{
    public class AdvertiesementRepository : IAdvertiesementRepository
    {
        private readonly BazaarDbContext _context;

        public AdvertiesementRepository(BazaarDbContext context)
        {
            _context = context;
        }

        public Advertiesement AddAdvertiesement(Advertiesement advertiesement)
        {
            return _context.Advertiesements.Add(advertiesement).Entity;
        }

        public AdvertiesementFeatureValue AddAdvertiesementFeatureValue(AdvertiesementFeatureValue advertiesementFeatureValue)
        {
            return _context.AdvertiesementFeatureValues.Add(advertiesementFeatureValue).Entity;
        }

        public AdvertiesementPicture AddAdvertiesementPicture(AdvertiesementPicture advertiesementPicture)
        {
            return _context.AdvertiesementPictures.Add(advertiesementPicture).Entity;
        }

        public AdvertiesementPrice AddAdvertiesementPrice(AdvertiesementPrice advertiesementPrice)
        {
            return _context.AdvertiesementPrice.Add(advertiesementPrice).Entity;
        }

        public void DeleteAdvertiesement(Advertiesement advertiesement)
        {
            _context.Advertiesements.Remove(advertiesement);
        }

        public void DeleteAdvertiesementFeatureValue(AdvertiesementFeatureValue advertiesementFeatureValue)
        {
            _context.AdvertiesementFeatureValues.Remove(advertiesementFeatureValue);
        }

        public void DeleteAdvertiesementPicture(AdvertiesementPicture advertiesementPicture)
        {
            _context.AdvertiesementPictures.Remove(advertiesementPicture);
        }

        public void DeleteAdvertiesementPrice(AdvertiesementPrice advertiesementPrice)
        {
            _context.AdvertiesementPrice.Remove(advertiesementPrice);
        }

        public Advertiesement? FindAdvertiesement(int id)
        {
            return _context.Advertiesements.Find(id);
        }

        public AdvertiesementFeatureValue? FindAdvertiesementFeatureValue(int advertiesementId)
        {
            return _context.AdvertiesementFeatureValues.Find(advertiesementId);
        }

        public AdvertiesementPicture? FindAdvertiesementPicture(int id)
        {
            return _context.AdvertiesementPictures.Find(id);
        }

        public AdvertiesementPrice? FindAdvertiesementPrice(int advertiesementId)
        {
            return _context.AdvertiesementPrice.Find(advertiesementId);
        }

        public IQueryable<AdvertiesementFeatureValue> GetAdvertiesementFeatureValues()
        {
            return _context.AdvertiesementFeatureValues.AsQueryable();
        }

        public IQueryable<AdvertiesementPicture> GetAdvertiesementPictures()
        {
            return _context.AdvertiesementPictures.AsQueryable();
        }

        public IQueryable<AdvertiesementPrice> GetAdvertiesementPrices()
        {
            return _context.AdvertiesementPrice.AsQueryable();
        }

        public IQueryable<Advertiesement> GetAdvertiesements()
        {
            return _context.Advertiesements.AsQueryable();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateAdvertiesement(Advertiesement advertiesement)
        {
            _context.Advertiesements.Update(advertiesement);
        }

        public void UpdateAdvertiesementFeatureValue(AdvertiesementFeatureValue advertiesementFeatureValue)
        {
            _context.AdvertiesementFeatureValues.Update(advertiesementFeatureValue);
        }

        public void UpdateAdvertiesementPicture(AdvertiesementPicture advertiesementPicture)
        {
            _context.AdvertiesementPictures.Update(advertiesementPicture);
        }

        public void UpdateAdvertiesementPrice(AdvertiesementPrice advertiesementPrice)
        {
            _context.AdvertiesementPrice.Update(advertiesementPrice);
        }
    }
}
