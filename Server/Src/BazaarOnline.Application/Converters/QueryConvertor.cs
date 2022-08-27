using BazaarOnline.Application.DTOs.Advertiesements.AdvertiesementFilterDTOs;
using Microsoft.AspNetCore.Http;

namespace BazaarOnline.Application.Converters
{
    public class QueryConvertor
    {
        /// <summary>
        /// finds query params with this format: 'f_{id}_{operation}'
        /// and converts them to `AdvertiesementFeatureFilterDTO`.
        /// there is 3 supported formats:
        /// 1- 'f_{id}': FilterTypeEnum will set to 'Equals'
        /// 2- 'f_{id}_gte': FilterTypeEnum will set to 'GreaterThanEqual'
        /// 3- 'f_{id}_lte': FilterTypeEnum will set to 'LessThanEqual'
        /// e.g: f_4_gte=50.
        /// </summary>
        /// <param name="query">Request query</param>
        /// <returns>list of 'AdvertiesementFeatureFilterDTO's that found</returns>
        public static List<AdvertiesementFeatureFilterDTO> ConvertToAdvertiesementFeatureFilter(IQueryCollection query)
        {
            var keys = query.Keys.Where(k => k.ToLower().StartsWith("f_"));
            var filters = new List<AdvertiesementFeatureFilterDTO>();

            foreach (var key in keys)
            {
                var keyOptions = key.Split('_').Skip(1);
                if (keyOptions.Count() < 1 || keyOptions.Count() > 2)
                    continue;

                int featureId;
                if (!Int32.TryParse(keyOptions.First(), out featureId))
                    continue;

                var filterDTO = new AdvertiesementFeatureFilterDTO();
                filterDTO.FeatureId = featureId;

                string? featureFilter = keyOptions.Skip(1).FirstOrDefault()?.ToLower();
                bool hasValidFilter = true;
                switch (featureFilter)
                {
                    case null:
                        filterDTO.FilterTypeEnum = FeatureFilterTypeEnum.Equals;
                        break;

                    case "gte":
                        filterDTO.FilterTypeEnum = FeatureFilterTypeEnum.GreaterThanEqual;
                        break;

                    case "lte":
                        filterDTO.FilterTypeEnum = FeatureFilterTypeEnum.LessThanEqual;
                        break;

                    default:
                        hasValidFilter = false;
                        break;
                }
                if (!hasValidFilter)
                    continue;

                filterDTO.FeatureValue = query[key];

                filters.Add(filterDTO);
            }
            return filters;
        }
    }
}
