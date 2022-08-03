namespace BazaarOnline.Application.DTOs.Permissions.RoleDTOs
{
    public class RoleUpdateDTO
    {
        public string Title { get; set; }

        public List<int> Permissions { get; set; }
    }
}
