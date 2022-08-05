namespace BazaarOnline.Application.DTOs.Users.UserDTOs
{
    public class UserFilterDTO
    {
        public string? Email { get; set; } = string.Empty;

        public string? Name { get; set; } = string.Empty;

        public bool? IsActive { get; set; } = null;

        public bool IsDeleted { get; set; } = false;

        public string? OrderBy { get; set; } = string.Empty;
    }
}
