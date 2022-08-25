using BazaarOnline.Application.DTOs.Advertiesements.AdvertiesementFilterDTOs;
using BazaarOnline.Application.DTOs.Advertiesements.AdvertiesementManagement;
using BazaarOnline.Application.DTOs.PaginationDTO;
using BazaarOnline.Application.ViewModels.Advertiesements.Management;
using BazaarOnline.Domain.Entities.Advertiesements;

namespace BazaarOnline.Application.Interfaces.Advertiesements
{
    public interface IAdvertiesementManagementService
    {
        Advertiesement? FindAdvertiesement(int id);
        void AcceptAdvertiesement(Advertiesement advertiesement);
        void DenyAdvertiesement(Advertiesement advertiesement, AdvertiesementDenyDTO denyDTO);
        void DeleteAdvertiesement(Advertiesement advertiesement, AdvertiesementDeleteDTO deleteDTO);

        PaginationResultDTO<AdvertiesementManagementListDetailViewModel>
            GetAdvertiesementListDetail(AdvertiesementManagementFilterDTO filter, PaginationFilterDTO pagination);


    }
}
