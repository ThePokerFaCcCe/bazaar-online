using BazaarOnline.Application.Interfaces.Permissions;
using BazaarOnline.Application.ViewModels.PermissionViewModels;
using BazaarOnline.Domain.Interfaces.Permissions;
using Microsoft.EntityFrameworkCore;

namespace BazaarOnline.Application.Services.Permissions
{
    public class PermissionService : IPermissionService
    {
        private readonly IPermissionRepository _permissionRepository;

        public PermissionService(IPermissionRepository permissionRepository)
        {
            _permissionRepository = permissionRepository;
        }

        public List<PermissionGroupDetailViewModel> GetPermissionGroups()
        {
            return _permissionRepository.GetPermissionGroups()
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
            return _permissionRepository.GetPermissions()
                .Select(p => p.Id)
                .ToList();
        }

        public bool HasUserPermission(int userId, int permissionId)
        {
            return _permissionRepository.HasUserPermission(userId, permissionId);
        }
    }
}
