using BazaarOnline.Domain.Entities.Permissions;
using BazaarOnline.Domain.Interfaces.Permissions;
using BazaarOnline.Infra.Data.Contexts;

namespace BazaarOnline.Infra.Data.Repositories.Permissions
{
    public class PermissionRepository : IPermissionRepository
    {
        private readonly BazaarDbContext _context;

        public PermissionRepository(BazaarDbContext context)
        {
            _context = context;
        }

        public IQueryable<PermissionGroup> GetPermissionGroups()
        {
            return _context.PermissionGroups.AsQueryable();
        }

        public IQueryable<Permission> GetPermissions()
        {
            return _context.Permissions.AsQueryable();
        }


        public List<int> GetUserPermissions(int userId)
        {
            var roles = _context.UserRoles.Where(ur => ur.UserId == userId)
                .Select(ur => ur.RoleId).ToList();

            return _context.RolePermissions
                .Where(rp => roles.Contains(rp.RoleId))
                .Select(rp => rp.PermissionId).ToList();
        }


        public bool HasUserPermission(int userId, int permissionId)
        {
            var perms = GetUserPermissions(userId);
            return perms.Contains(permissionId);
        }

    }
}
