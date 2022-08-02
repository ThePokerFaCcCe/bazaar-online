using System.ComponentModel.DataAnnotations;
using BazaarOnline.Domain.Entities.Users;

namespace BazaarOnline.Domain.Entities.Permissions
{
    public class Role
    {
        public int Id { get; set; }

        public string Title { get; set; }

        #region Relations

        public List<RolePermission> RolePermissions { get; set; }
        public List<UserRole> UserRoles { get; set; }

        #endregion
    }
}
