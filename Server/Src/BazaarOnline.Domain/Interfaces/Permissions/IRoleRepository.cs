using BazaarOnline.Domain.Entities.Permissions;
using BazaarOnline.Domain.Entities.Users;

namespace BazaarOnline.Domain.Interfaces.Permissions
{
    public interface IRoleRepository
    {
        void Save();

        IQueryable<Role> GetRoles();
        Role AddRole(Role role);

        /// <summary>
        /// Updating a role
        /// </summary>
        /// <param name="role">Role to Update. if role exists in UneditableRoles, ArgumentException will be thrown</param>
        /// <exception cref="ArgumentException"></exception>
        void UpdateRole(Role role);

        /// <summary>
        /// Deleting a role
        /// </summary>
        /// <param name="role">Role to delete. if role exists in UneditableRoles, ArgumentException will be thrown</param>
        /// <exception cref="ArgumentException"></exception>
        void DeleteRole(Role role);

        #region RolePermission
        // IQueryable<RolePermission> GetRolePermissions(int[] roleIds);
        IQueryable<RolePermission> GetRolePermissions();
        IQueryable<RolePermission> GetRolePermissions(int roleId);
        void AddRolePermissionRange(List<int> permissions, int roleId);
        void DeleteRolePermissionRange(List<int> permissions, int roleId);

        #endregion
    }
}
