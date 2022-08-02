using BazaarOnline.Domain.Entities.Permissions;
using BazaarOnline.Domain.Entities.Users;
using BazaarOnline.Domain.Interfaces.Permissions;
using BazaarOnline.Infra.Data.Contexts;

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

        public void DeleteUserRoleRange(List<int> roles, int userId)
        {
            _context.UserRoles.RemoveRange(
                _context.UserRoles
                    .Where(ur => ur.UserId == userId && roles.Contains(ur.RoleId))
            );
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
    }
}
