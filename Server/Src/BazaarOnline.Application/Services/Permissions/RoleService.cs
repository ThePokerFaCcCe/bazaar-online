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
        private readonly IRepository _repository;

        public RoleService(IRepository repository)
        {
            _repository = repository;
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


            var role = _repository.Add<Role>(new Role
            {
                Title = roleModel.Title,
                RolePermissions = rolePermissions,
            });

            _repository.Save();
            return role.Id;
        }

        public void DeleteRole(Role role)
        {
            _repository.Remove<Role>(role);
            _repository.Save();
        }

        public Role? FindRole(int id)
        {
            return _repository.GetAll<Role>()
                .Include(r => r.RolePermissions)
                .SingleOrDefault(r => r.Id == id);
        }

        public RoleDetailViewModel? GetRoleDetail(int id)
        {
            return _repository.GetAll<Role>()
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
            return _repository.GetAll<Role>().Select(r => r.Id).ToList();
        }

        public List<RoleDetailListViewModel> GetRoles()
        {
            return _repository.GetAll<Role>()
                .Select(r => new RoleDetailListViewModel
                {
                    Id = r.Id,
                    Title = r.Title,
                }).ToList();
        }

        public bool IsRoleExists(string title)
        {
            return _repository.GetAll<Role>()
                .Any(r => r.Title.ToLower() == title.Trim().ToLower());
        }

        public bool IsRoleUneditable(int roleId)
        {
            return DefaultRoles.UneditableRoles
                .Any(r => r.Id == roleId);
        }

        public void UpdateRole(Role role, RoleUpdateDTO updateDTO)
        {
            var rolePermissions = _repository.GetAll<RolePermission>()
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

            _repository.AddRange<RolePermission>(newPerms);
            _repository.RemoveRange<RolePermission>(removedPerms);

            role.Title = updateDTO.Title.Trim();
            _repository.Update<Role>(role);
            _repository.Save();
        }
    }
}
