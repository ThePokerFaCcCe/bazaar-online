using BazaarOnline.Domain.Entities.Users;

namespace BazaarOnline.Domain.Interfaces.Users
{
    public interface IUserRepository
    {
        IQueryable<User> GetUsers();
        User? FindUser(int id);

        User AddUser(User user);

        void UpdateUser(User user);

        /// <summary>
        /// Set User.IsDeleted Property to true
        /// </summary>
        /// <param name="user">user to soft delete</param>
        void SoftDeleteUser(User user);

        #region UserRole

        UserRole AddUserRole(UserRole userRole);
        void AddUserRoleRange(List<int> roles, User user);
        void DeleteUserRoleRange(List<int> roles, User user);
        IQueryable<UserRole> GetUserRoles(User user);

        #endregion

        void Save();
    }
}
