using BazaarOnline.Application.DTOs.Users.UserDTOs;
using BazaarOnline.Application.Interfaces.Permissions;
using BazaarOnline.Application.ViewModels.PermissionViewModels;
using BazaarOnline.Application.ViewModels.RoleViewModels;
using BazaarOnline.Domain.Entities.Permissions;
using BazaarOnline.Domain.Interfaces.Permissions;
using Microsoft.EntityFrameworkCore;

namespace BazaarOnline.Application.Services.Permissions
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public RoleDetailViewModel CreateRole(RoleCreateViewModel roleModel)
        {
            var rolePermissions = new List<RolePermission>();
            roleModel.Permissions.ForEach(p => rolePermissions.Add(
                new RolePermission
                {
                    PermissionId = p
                }
            ));


            var role = _roleRepository.AddRole(new Role
            {
                Title = roleModel.Title,
                RolePermissions = rolePermissions,
            });

            _roleRepository.Save();
            return FindRole(role.Id);
        }

        public RoleDetailViewModel? FindRole(int id)
        {
            return _roleRepository.GetRoles()
                .Include(r => r.RolePermissions)
                .ThenInclude(rp => rp.Permission)
                .Where(r => r.Id == id)
                .Select(r => new RoleDetailViewModel
                {
                    Id = r.Id,
                    RoleTitle = r.Title,
                    Permissions = r.RolePermissions
                        .OrderBy(rp => rp.Permission.PermissionGroupId)
                        .Select(rp => new PermissionDetailViewModel
                        {
                            Id = rp.Permission.Id,
                            Title = rp.Permission.Title,
                        }).ToList(),

                }).SingleOrDefault();
        }

        public List<int> GetRoleIds()
        {
            return _roleRepository.GetRoles().Select(r => r.Id).ToList();
        }

        public List<RoleDetailListViewModel> GetRoles()
        {
            return _roleRepository.GetRoles()
                .Select(r => new RoleDetailListViewModel
                {
                    Id = r.Id,
                    Title = r.Title,
                }).ToList();
        }

        public bool IsRoleExists(string title)
        {
            return _roleRepository.GetRoles()
                .Any(r => r.Title.ToLower() == title.Trim().ToLower());
        }

        public void UpdateUserRoles(int userId, UserUpdateRoleDTO updateRoleDTO)
        {
            var roles = updateRoleDTO.Roles;
            var oldRoles = _roleRepository.GetUserRoles(userId)
                .Select(ur => ur.RoleId).ToList();

            var removedRoles = oldRoles.Except(roles).ToList();
            var newRoles = roles.Except(oldRoles).ToList();

            _roleRepository.AddUserRoleRange(newRoles, userId);
            _roleRepository.DeleteUserRoleRange(removedRoles, userId);
            _roleRepository.Save();
        }
    }
}
