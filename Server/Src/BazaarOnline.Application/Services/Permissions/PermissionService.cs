using BazaarOnline.Application.Interfaces.Permissions;
using BazaarOnline.Application.ViewModels.PermissionViewModels;
using BazaarOnline.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BazaarOnline.Application.Services.Permissions
{
    public class PermissionService : IPermissionService
    {
        private readonly IRepositories _repositories;

        public List<PermissionGroupDetailViewModel> GetPermissionGroups()
        {
            return _repositories.PermissionGroups.GetAll()
                .Include(pg => pg.Permissions)
                .Select(pg => new PermissionGroupDetailViewModel
                {
                    GroupTitle = pg.Title,
                    Permissions = pg.Permissions
                        .Select(p => new PermissionDetailViewModel
                        {
                            Id = p.Id,
                            Title = p.Title,
                        }).ToList()
                }).ToList();
        }

        public List<int> GetPermissionIds()
        {
            return _repositories.Permissions.GetAll()
                .Select(p => p.Id)
                .ToList();
        }

        public bool HasUserPermission(int userId, int permissionId)
        {
            var roles = _repositories.UserRoles.GetAll()
                .Where(ur => ur.UserId == userId)
                .Select(ur => ur.RoleId);

            return _repositories.RolePermissions.GetAll()
                .Any(rp => roles.Contains(rp.RoleId) && rp.PermissionId == permissionId);
        }
    }
}
