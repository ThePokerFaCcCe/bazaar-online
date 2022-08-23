using BazaarOnline.Application.Filters.Generic.Attributes;

namespace BazaarOnline.Application.DTOs.Users.UserDTOs
{
    public class UserFilterDTO
    {
        [Filter(FilterTypeEnum.ModelContainsThis)]
        public string? Email { get; set; }

        [Filter(FilterTypeEnum.Equals)]
        public bool? IsActive { get; set; }

        [Filter(FilterTypeEnum.Equals)]
        public bool IsDeleted { get; set; } = false;

        public string? OrderBy { get; set; }
    }
}
