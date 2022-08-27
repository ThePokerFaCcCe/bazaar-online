using BazaarOnline.Application.DTOs.Advertiesements.AdvertiesementFilterDTOs;
using BazaarOnline.Domain.Entities.Advertiesements;
using Microsoft.EntityFrameworkCore;

namespace BazaarOnline.Application.Filters.Advertiesements
{
    public static class AdvertiesementFeatureFilterExtention
    {
        public static IQueryable<Advertiesement> FilterByFeatures(
            this IQueryable<Advertiesement> query,
            List<AdvertiesementFeatureFilterDTO> featureFilterDTO)
        {
            query = query.Include(a => a.AdvertiesementFeatureValues);
            foreach (var filter in featureFilterDTO)
            {
                switch (filter.FilterTypeEnum)
                {
                    case FeatureFilterTypeEnum.Equals:
                        query = query
                            .Where(a => a.AdvertiesementFeatureValues
                                .Any(af => af.FeatureId == filter.FeatureId
                                    && af.Value == filter.FeatureValue));
                        break;

                    case FeatureFilterTypeEnum.GreaterThanEqual:
                        query = query
                            .Where(a => a.AdvertiesementFeatureValues
                                .Any(af => af.FeatureId == filter.FeatureId
                                    && Convert.ToDouble(af.Value) >= Convert.ToDouble(filter.FeatureValue)));
                        break;

                    case FeatureFilterTypeEnum.LessThanEqual:
                        query = query
                            .Where(a => a.AdvertiesementFeatureValues
                                .Any(af => af.FeatureId == filter.FeatureId
                                    && Convert.ToDouble(af.Value) <= Convert.ToDouble(filter.FeatureValue)));
                        break;
                }
            }
            return query;
        }
    }
}
