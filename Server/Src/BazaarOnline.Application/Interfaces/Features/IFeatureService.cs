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

        Feature CreateFeature(FeatureCreateDTO createDTO);
    }
}
