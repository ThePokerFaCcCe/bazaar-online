using BazaarOnline.Domain.Entities.Features;
using BazaarOnline.Domain.Interfaces.Features;
using BazaarOnline.Infra.Data.Contexts;

namespace BazaarOnline.Infra.Data.Repositories.Features
{
    public class FeatureRepository : IFeatureRepository
    {
        private readonly BazaarDbContext _context;

        public FeatureRepository(BazaarDbContext context)
        {
            _context = context;
        }

        public Feature AddFeature(Feature feature)
        {
            return _context.Features.Add(feature).Entity;
        }

        public FeatureEnum AddFeatureEnum(FeatureEnum featureEnum)
        {
            return _context.FeatureEnums.Add(featureEnum).Entity;
        }

        public FeatureEnumValue AddFeatureEnumValue(FeatureEnumValue featureEnumValue)
        {
            return _context.FeatureEnumValues.Add(featureEnumValue).Entity;
        }

        public void AddFeatureEnumValueRange(FeatureEnumValue[] featureEnumValues)
        {
            _context.FeatureEnumValues.AddRange(featureEnumValues);
        }

        public FeatureInteger AddFeatureInteger(FeatureInteger featureInteger)
        {
            return _context.FeatureIntegers.Add(featureInteger).Entity;
        }

        public void DeleteFeature(Feature feature)
        {
            _context.Features.Remove(feature);
        }

        public void DeleteFeatureEnum(FeatureEnum featureEnum)
        {
            _context.FeatureEnums.Remove(featureEnum);
        }

        public void DeleteFeatureEnumValue(FeatureEnumValue featureEnumValue)
        {
            _context.FeatureEnumValues.Remove(featureEnumValue);
        }

        public void DeleteFeatureEnumValueRange(int featureEnumId)
        {
            _context.FeatureEnumValues.RemoveRange(
                _context.FeatureEnumValues
                    .Where(fev => fev.FeatureEnumId == featureEnumId)
            );
        }

        public void DeleteFeatureInteger(FeatureInteger featureInteger)
        {
            _context.FeatureIntegers.Remove(featureInteger);
        }

        public Feature? FindFeature(int id)
        {
            return _context.Features.Find(id);
        }

        public FeatureEnum? FindFeatureEnum(int id)
        {
            return _context.FeatureEnums.Find(id);
        }

        public FeatureEnumValue? FindFeatureEnumValue(int id)
        {
            return _context.FeatureEnumValues.Find(id);
        }

        public FeatureInteger? FindFeatureInteger(int id)
        {
            return _context.FeatureIntegers.Find(id);
        }

        public IQueryable<FeatureEnum> GetFeatureEnums()
        {
            return _context.FeatureEnums.AsQueryable();
        }

        public IQueryable<FeatureEnumValue> GetFeatureEnumValues()
        {
            return _context.FeatureEnumValues.AsQueryable();
        }

        public IQueryable<FeatureInteger> GetFeatureIntegers()
        {
            return _context.FeatureIntegers.AsQueryable();
        }

        public IQueryable<Feature> GetFeatures()
        {
            return _context.Features.AsQueryable();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateFeature(Feature feature)
        {
            _context.Features.Update(feature);
        }

        public void UpdateFeatureEnum(FeatureEnum featureEnum)
        {
            _context.FeatureEnums.Update(featureEnum);
        }

        public void UpdateFeatureEnumValue(FeatureEnumValue featureEnumValue)
        {
            _context.FeatureEnumValues.Update(featureEnumValue);
        }

        public void UpdateFeatureInteger(FeatureInteger featureInteger)
        {
            _context.FeatureIntegers.Update(featureInteger);
        }
    }
}
