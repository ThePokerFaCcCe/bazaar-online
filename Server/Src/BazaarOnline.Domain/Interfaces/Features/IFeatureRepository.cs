using BazaarOnline.Domain.Entities.Features;

namespace BazaarOnline.Domain.Interfaces.Features
{
    public interface IFeatureRepository
    {
        void Save();

        #region Feature
        IQueryable<Feature> GetFeatures();
        Feature? FindFeature(int id);
        Feature AddFeature(Feature feature);
        void UpdateFeature(Feature feature);
        void DeleteFeature(Feature feature);
        #endregion

        #region FeatureEnum
        IQueryable<FeatureEnum> GetFeatureEnums();
        FeatureEnum? FindFeatureEnum(int id);
        FeatureEnum AddFeatureEnum(FeatureEnum featureEnum);
        void UpdateFeatureEnum(FeatureEnum featureEnum);
        void DeleteFeatureEnum(FeatureEnum featureEnum);
        #endregion

        #region FeatureEnumValue
        IQueryable<FeatureEnumValue> GetFeatureEnumValues();
        FeatureEnumValue? FindFeatureEnumValue(int id);
        FeatureEnumValue AddFeatureEnumValue(FeatureEnumValue featureEnumValue);
        void UpdateFeatureEnumValue(FeatureEnumValue featureEnumValue);
        void DeleteFeatureEnumValue(FeatureEnumValue featureEnumValue);
        #endregion

        #region FeatureInteger
        IQueryable<FeatureInteger> GetFeatureIntegers();
        FeatureInteger? FindFeatureInteger(int id);
        FeatureInteger AddFeatureInteger(FeatureInteger featureInteger);
        void UpdateFeatureInteger(FeatureInteger featureInteger);
        void DeleteFeatureInteger(FeatureInteger featureInteger);
        #endregion
    }
}
