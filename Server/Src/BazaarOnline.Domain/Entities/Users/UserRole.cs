using BazaarOnline.Domain.Entities.Permissions;

namespace BazaarOnline.Domain.Entities.Users
{
    public class UserRole
    {
        public int RoleId { get; set; }
        public int UserId { get; set; }

        #region Relations

        public Role Role { get; set; }
        public User User { get; set; }


        #endregion
    }
}
