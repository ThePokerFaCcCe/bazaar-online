using BazaarOnline.Application.ViewModels.PermissionViewModels;

namespace BazaarOnline.Application.Interfaces.Permissions
{
    public interface IPermissionService
    {
        List<PermissionGroupDetailViewModel> GetPermissionGroups();
        List<int> GetPermissionIds();
        bool HasUserPermission(int userId, int permissionId);

    }
}
