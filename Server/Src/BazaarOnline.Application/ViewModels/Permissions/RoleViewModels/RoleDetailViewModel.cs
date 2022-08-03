using BazaarOnline.Application.ViewModels.PermissionViewModels;

namespace BazaarOnline.Application.ViewModels.RoleViewModels
{
    public class RoleDetailViewModel
    {
        public int Id { get; set; }
        public string RoleTitle { get; set; }
        public List<PermissionDetailViewModel> Permissions { get; set; }
    }
}
