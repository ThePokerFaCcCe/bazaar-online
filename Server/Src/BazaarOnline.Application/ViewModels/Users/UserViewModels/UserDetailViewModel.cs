using BazaarOnline.Domain.Entities.Permissions;

namespace BazaarOnline.Application.ViewModels.Users.UserViewModels
{
    public class UserDetailViewModel
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime CreateDate { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsActive { get; set; }

        public bool IsEmailActive { get; set; }

        public List<UserRoleDetailListViewModel> Roles { get; set; }
    }
}
