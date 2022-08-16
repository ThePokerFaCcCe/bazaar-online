using BazaarOnline.Application.Interfaces.Permissions;
using BazaarOnline.Application.ViewModels.PermissionViewModels;
using BazaarOnline.Domain.Entities.Permissions;
using BazaarOnline.Domain.Entities.Users;
using BazaarOnline.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BazaarOnline.Application.Services.Permissions
{
    public class PermissionService : IPermissionService
    {
        private readonly IRepository _repository;

        public PermissionService(IRepository repository)
        {
            _repository = repository;
        }

        public List<PermissionGroupDetailViewModel> GetPermissionGroups()
        {
            return _repository.GetAll<PermissionGroup>()
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
            return _repository.GetAll<Permission>()
                .Select(p => p.Id)
                .ToList();
        }

        public bool HasUserPermission(int userId, int permissionId)
        {
            var roles = _repository.GetAll<UserRole>()
                .Where(ur => ur.UserId == userId)
                .Select(ur => ur.RoleId);

            return _repository.GetAll<RolePermission>()
                .Any(rp => roles.Contains(rp.RoleId) && rp.PermissionId == permissionId);
        }
    }
}
