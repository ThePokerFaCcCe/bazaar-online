using BazaarOnline.Domain.Entities.Permissions;
using BazaarOnline.Domain.Entities.Users;

namespace BazaarOnline.Domain.Interfaces.Permissions
{
    public interface IRoleRepository
    {
        void Save();

        IQueryable<Role> GetRoles();
        Role AddRole(Role role);
        // void UpdateRole(Role role);
        // void DeleteRole(Role role);

        #region UserRole

        UserRole AddUserRole(UserRole userRole);
        void AddUserRoleRange(List<int> roles, int userId);
        void DeleteUserRoleRange(List<int> roles, int userId);
        IQueryable<UserRole> GetUserRoles(int userId);

        #endregion
    }
}
