using System.ComponentModel.DataAnnotations;

namespace BazaarOnline.Domain.Entities.Permissions
{
    public class PermissionGroup
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        #region Relations

        public List<Permission> Permissions { get; set; }

        #endregion
    }
}
