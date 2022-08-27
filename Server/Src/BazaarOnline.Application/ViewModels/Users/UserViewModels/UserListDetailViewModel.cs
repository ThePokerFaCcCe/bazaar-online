namespace BazaarOnline.Application.ViewModels.Users.UserViewModels
{
    public class UserListDetailViewModel
    {
        public int Id { get; set; }

        public string PhoneNumber { get; set; }

        public string FullName { get; set; }

        public DateTime CreateDate { get; set; }

        public bool IsActive { get; set; }
    }
}
