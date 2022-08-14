using BazaarOnline.Application.DTOs.Features;
using BazaarOnline.Application.DTOs.PaginationDTO;
using BazaarOnline.Application.ViewModels.Features;
using BazaarOnline.Domain.Entities.Features;

namespace BazaarOnline.Application.Interfaces.Features
{
    public interface IFeatureService
    {
        PaginationResultDTO<FeatureListDetailViewModel> GetFeatureListDetail(
            FeatureFilterDTO filter, PaginationFilterDTO pagination);

        FeatureDetailViewModel? GetFeatureDetail(int id);

        Feature? FindFeature(int id, bool includeType = false);

        Feature CreateFeature(FeatureCreateDTO createDTO);

        void UpdateFeatureEnum(FeatureEnum featureEnum, FeatureEnumUpdateDTO updateDTO);
        void UpdateFeatureInteger(FeatureInteger featureInteger, FeatureIntegerUpdateDTO updateDTO);
    }
}
