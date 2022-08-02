using BazaarOnline.Domain.Entities.Permissions;

namespace BazaarOnline.Domain.Interfaces.Permissions
{
    public interface IPermissionRepository
    {
        IQueryable<PermissionGroup> GetPermissionGroups();
        IQueryable<Permission> GetPermissions();

        #region UserPermissions

        List<int> GetUserPermissions(int userId);
        bool HasUserPermission(int userId, int permissionId);

        #endregion

    }
}
