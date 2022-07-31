using BazaarOnline.Domain.Entities.Users;

namespace BazaarOnline.Domain.Interfaces.Users
{
    public interface IUserRepository
    {
        IQueryable<User> GetUsers();

        User AddUser(User user);

        void UpdateUser(User user);

        void Save();
    }
}
