using BazaarOnline.Application.DTOs.Permissions.RoleDTOs;
using BazaarOnline.Application.DTOs.Users.UserDTOs;
using BazaarOnline.Application.ViewModels.RoleViewModels;
using BazaarOnline.Domain.Entities.Permissions;
using BazaarOnline.Domain.Entities.Users;

namespace BazaarOnline.Application.Interfaces.Permissions
{
    public interface IRoleService
    {
        List<RoleDetailListViewModel> GetRoles();
        List<int> GetRoleIds();
        Role? FindRole(int id);
        RoleDetailViewModel? GetRoleDetail(int id);

        int CreateRole(RoleCreateDTO roleModel);

        void UpdateRole(Role role, RoleUpdateDTO updateDTO);
        void DeleteRole(Role role);

        /// <summary>
        /// Checks if the role is one of UneditableRoles inside of DefaultRoles class
        /// </summary>
        /// <param name="roleId">role id to check</param>
        /// <returns>Returns true if role is uneditable and can't be edites</returns>
        bool IsRoleUneditable(int roleId);
        bool IsRoleExists(string title);


        #region UserRoles

        void UpdateUserRoles(User user, UserUpdateRoleDTO updateRoleDTO);

        #endregion

    }
}
