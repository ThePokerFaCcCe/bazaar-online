using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BazaarOnline.Domain.Entities.Advertiesements;

namespace BazaarOnline.Domain.Entities.Users
{
    public class User
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string? PhoneNumber { get; set; }

        public string Password { get; set; }

        public DateTime CreateDate { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsActive { get; set; }

        [NotMapped]
        public string FullName => $"{FirstName} {LastName}".Trim();

        #region Relations
        public List<UserRole> UserRoles { get; set; }

        public List<Advertiesement> Advertiesements { get; set; }

        #endregion
    }
}
