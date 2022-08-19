using BazaarOnline.Application.DTOs.Advertiesements;
using BazaarOnline.Application.ViewModels.Advertiesements;
using BazaarOnline.Domain.Entities.Advertiesements;

namespace BazaarOnline.Application.Interfaces.Advertiesements
{
    public interface IAdvertiesementService
    {
        AdvertiesementDetailViewModel? GetAdvertiesementDetail(int id);
        // IEnumerable<AdvertiesementListDetailViewModel> GetAdvertiesementListDetail();
        Advertiesement CreateAdvertiesement(AdvertiesementCreateDTO createDTO, int userId);
    }
}
