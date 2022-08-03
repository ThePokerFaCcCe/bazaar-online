using BazaarOnline.Application.DTOs.Users.UserDTOs;
using BazaarOnline.Application.ViewModels.RoleViewModels;

namespace BazaarOnline.Application.Interfaces.Permissions
{
    public interface IRoleService
    {
        List<RoleDetailListViewModel> GetRoles();
        List<int> GetRoleIds();
        RoleDetailViewModel? FindRole(int id);

        RoleDetailViewModel CreateRole(RoleCreateViewModel roleModel);

        bool IsRoleExists(string title);


        #region UserRoles

        void UpdateUserRoles(int userId, UserUpdateRoleDTO updateRoleDTO);

        #endregion

    }
}
