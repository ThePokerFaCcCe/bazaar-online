using BazaarOnline.Application.DTOs.Advertiesements;
using BazaarOnline.Application.DTOs.Advertiesements.AdvertiesementFilterDTOs;
using BazaarOnline.Application.DTOs.PaginationDTO;
using BazaarOnline.Application.ViewModels.Advertiesements;
using BazaarOnline.Domain.Entities.Advertiesements;

namespace BazaarOnline.Application.Interfaces.Advertiesements
{
    public interface IAdvertiesementService
    {
        PaginationResultDTO<AdvertiesementListDetailViewModel>
            GetAdvertiesementListDetail(AdvertiesementGlobalFilterDTO filter,
                                        List<AdvertiesementFeatureFilterDTO> featureFilter,
                                        PaginationFilterDTO pagination);

        AdvertiesementDetailViewModel? GetAdvertiesementDetail(int id);
        Advertiesement CreateAdvertiesement(AdvertiesementCreateDTO createDTO, int userId);
        Advertiesement? FindAdvertiesement(int id);
        void DeleteAdvertiesement(Advertiesement advertiesement);
        AdvertiesementContactDetailViewModel GetAdvertiesementContactDetail(Advertiesement advertiesement);
    }
}
