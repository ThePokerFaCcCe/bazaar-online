using BazaarOnline.Domain.Entities.Advertiesements;

namespace BazaarOnline.Application.Interfaces.Advertiesements
{
    public interface IAdvertiesementManagementService
    {
        Advertiesement? FindAdvertiesement(int id);
        void AcceptAdvertiesement(Advertiesement advertiesement);
        void DenyAdvertiesement(Advertiesement advertiesement, string? reason = null);
    }
}
