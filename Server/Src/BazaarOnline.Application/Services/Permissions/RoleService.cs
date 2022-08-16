using BazaarOnline.Application.DTOs.Permissions.RoleDTOs;
using BazaarOnline.Application.Interfaces.Permissions;
using BazaarOnline.Application.ViewModels.PermissionViewModels;
using BazaarOnline.Application.ViewModels.RoleViewModels;
using BazaarOnline.Domain.Entities.Permissions;
using BazaarOnline.Domain.Interfaces;
using BazaarOnline.Infra.Data.Seeds.DefaultDatas;
using Microsoft.EntityFrameworkCore;

namespace BazaarOnline.Application.Services.Permissions
{
    public class RoleService : IRoleService
    {
        private readonly IRepositories _repositories;

        public RoleService(IRepositories repositories)
        {
            _repositories = repositories;
        }

        public int CreateRole(RoleCreateDTO roleModel)
        {
            var rolePermissions = new List<RolePermission>();
            roleModel.Permissions.ForEach(p => rolePermissions.Add(
                new RolePermission
                {
                    PermissionId = p
                }
            ));


            var role = _repositories.Roles.Add(new Role
            {
                Title = roleModel.Title,
                RolePermissions = rolePermissions,
            });

            _repositories.Roles.Save();
            return role.Id;
        }

        public void DeleteRole(Role role)
        {
            _repositories.Roles.Remove(role);
            _repositories.Roles.Save();
        }

        public Role? FindRole(int id)
        {
            return _repositories.Roles.GetAll()
                .Include(r => r.RolePermissions)
                .SingleOrDefault(r => r.Id == id);
        }

        public RoleDetailViewModel? GetRoleDetail(int id)
        {
            return _repositories.Roles.GetAll()
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
            return _repositories.Roles.GetAll().Select(r => r.Id).ToList();
        }

        public List<RoleDetailListViewModel> GetRoles()
        {
            return _repositories.Roles.GetAll()
                .Select(r => new RoleDetailListViewModel
                {
                    Id = r.Id,
                    Title = r.Title,
                }).ToList();
        }

        public bool IsRoleExists(string title)
        {
            return _repositories.Roles.GetAll()
                .Any(r => r.Title.ToLower() == title.Trim().ToLower());
        }

        public bool IsRoleUneditable(int roleId)
        {
            return DefaultRoles.UneditableRoles
                .Any(r => r.Id == roleId);
        }

        public void UpdateRole(Role role, RoleUpdateDTO updateDTO)
        {
            var rolePermissions = _repositories.RolePermissions
                .GetAll()
                .Where(rp => rp.RoleId == role.Id);

            var newPerms = updateDTO.Permissions
                .Except(rolePermissions.Select(rp => rp.PermissionId))
                .Select(p => new RolePermission
                {
                    RoleId = role.Id,
                    PermissionId = p,
                });
            var removedPerms = rolePermissions
                .Where(rp => !updateDTO.Permissions.Contains(rp.PermissionId));

            _repositories.RolePermissions.AddRange(newPerms);
            _repositories.RolePermissions.RemoveRange(removedPerms);

            role.Title = updateDTO.Title.Trim();
            _repositories.Roles.Update(role);
            _repositories.Roles.Save();
        }
    }
}
