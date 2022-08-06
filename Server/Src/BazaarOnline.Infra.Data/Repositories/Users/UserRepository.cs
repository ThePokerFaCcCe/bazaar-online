using BazaarOnline.Domain.Entities.Users;
using BazaarOnline.Domain.Interfaces.Users;
using BazaarOnline.Infra.Data.Contexts;

namespace BazaarOnline.Infra.Data.Repositories.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly BazaarDbContext _context;

        public UserRepository(BazaarDbContext context)
        {
            _context = context;
        }

        public User AddUser(User user)
        {
            return _context.Users.Add(user).Entity;
        }

        public User? FindUser(int id)
        {
            return _context.Users.Find(id);
        }

        public UserRole AddUserRole(UserRole userRole)
        {
            return _context.UserRoles.Add(userRole).Entity;
        }

        public void AddUserRoleRange(List<int> roles, User user)
        {
            var userRoles = new List<UserRole>();
            roles.ForEach(roleId => userRoles.Add(new UserRole
            {
                UserId = user.Id,
                RoleId = roleId,
            }));
            _context.UserRoles.AddRange(userRoles);
        }



        public void DeleteUserRoleRange(List<int> roles, User user)
        {
            _context.UserRoles.RemoveRange(
                _context.UserRoles
                    .Where(ur => ur.UserId == user.Id && roles.Contains(ur.RoleId))
            );
        }


        public IQueryable<UserRole> GetUserRoles(User user)
        {
            return _context.UserRoles.Where(ur => ur.UserId == user.Id).AsQueryable();
        }


        public IQueryable<User> GetUsers()
        {
            return _context.Users.AsQueryable();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void SoftDeleteUser(User user)
        {
            user.IsDeleted = true;
            _context.Users.Update(user);
        }

        public void UpdateUser(User user)
        {
            _context.Users.Update(user);
        }
    }
}
