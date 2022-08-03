using BazaarOnline.Domain.Entities.Permissions;
using BazaarOnline.Domain.Entities.Users;
using BazaarOnline.Domain.Interfaces.Permissions;
using BazaarOnline.Infra.Data.Contexts;
using BazaarOnline.Infra.Data.Seeds.DefaultDatas;

namespace BazaarOnline.Infra.Data.Repositories.Permissions
{
    public class RoleRepository : IRoleRepository
    {
        private readonly BazaarDbContext _context;

        public RoleRepository(BazaarDbContext context)
        {
            _context = context;
        }

        public Role AddRole(Role role)
        {
            return _context.Roles.Add(role).Entity;
        }

        public void AddRolePermissionRange(List<int> permissions, int roleId)
        {
            var rolePermissions = new List<RolePermission>();
            permissions.ForEach(p => rolePermissions.Add(new RolePermission
            {
                PermissionId = p,
                RoleId = roleId,
            }));
            _context.RolePermissions.AddRange(rolePermissions);
        }

        public UserRole AddUserRole(UserRole userRole)
        {
            return _context.UserRoles.Add(userRole).Entity;
        }

        public void AddUserRoleRange(List<int> roles, int userId)
        {
            var userRoles = new List<UserRole>();
            roles.ForEach(roleId => userRoles.Add(new UserRole
            {
                UserId = userId,
                RoleId = roleId,
            }));
            _context.UserRoles.AddRange(userRoles);
        }

        public void DeleteRole(Role role)
        {
            if (DefaultRoles.UneditableRoles.Any(r => r.Id == role.Id))
                throw new ArgumentException("You cannot Remove this role");
            _context.Roles.Remove(role);
        }

        public void DeleteRolePermissionRange(List<int> permissions, int roleId)
        {
            _context.RolePermissions.RemoveRange(
                _context.RolePermissions
                    .Where(rp => rp.RoleId == roleId && permissions.Contains(rp.PermissionId))
            );
        }

        public void DeleteUserRoleRange(List<int> roles, int userId)
        {
            _context.UserRoles.RemoveRange(
                _context.UserRoles
                    .Where(ur => ur.UserId == userId && roles.Contains(ur.RoleId))
            );
        }

        public IQueryable<RolePermission> GetRolePermissions()
        {
            return _context.RolePermissions.AsQueryable();
        }

        public IQueryable<RolePermission> GetRolePermissions(int roleId)
        {
            return _context.RolePermissions.
                Where(rp => rp.RoleId == roleId).AsQueryable();
        }

        public IQueryable<Role> GetRoles()
        {
            return _context.Roles.AsQueryable();
        }

        public IQueryable<UserRole> GetUserRoles(int userId)
        {
            return _context.UserRoles.Where(ur => ur.UserId == userId).AsQueryable();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateRole(Role role)
        {
            if (DefaultRoles.UneditableRoles.Any(r => r.Id == role.Id))
                throw new ArgumentException("You cannot Update this role");
            _context.Roles.Update(role);
        }
    }
}
