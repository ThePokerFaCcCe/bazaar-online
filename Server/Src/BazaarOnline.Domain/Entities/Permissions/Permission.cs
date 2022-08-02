using System.ComponentModel.DataAnnotations;

namespace BazaarOnline.Domain.Entities.Permissions
{
    public class Permission
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public int PermissionGroupId { get; set; }

        #region relations

        public PermissionGroup PermissionGroup { get; set; }

        public List<RolePermission> RolePermissions { get; set; }

        #endregion

    }
}
