using BazaarOnline.Application.DTOs.Advertiesements.AdvertiesementManagement;
using BazaarOnline.Domain.Entities.Advertiesements;

namespace BazaarOnline.Application.Interfaces.Advertiesements
{
    public interface IAdvertiesementManagementService
    {
        Advertiesement? FindAdvertiesement(int id);
        void AcceptAdvertiesement(Advertiesement advertiesement);
        void DenyAdvertiesement(Advertiesement advertiesement, AdvertiesementDenyDTO denyDTO);
        void DeleteAdvertiesement(Advertiesement advertiesement, AdvertiesementDeleteDTO deleteDTO);
    }
}
