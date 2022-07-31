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

        public IQueryable<User> GetUsers()
        {
            return _context.Users.AsQueryable();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            _context.Users.Update(user);
        }
    }
}
