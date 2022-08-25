using BazaarOnline.Application.Filters.Generic.Attributes;
using BazaarOnline.Domain.Entities.Users;

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

        [Order(nameof(User.CreateDate))]
        [Order(nameof(User.FirstName))]
        [Order(nameof(User.LastName))]
        [Order(nameof(User.CreateDate))]
        [Order(nameof(User.Email))]
        [Order(nameof(User.IsActive))]
        public string? OrderBy { get; set; }
    }
}
