using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using BazaarOnline.Application.Filters.Generic.Attributes;

namespace BazaarOnline.Application.DTOs.Users.UserDTOs
{
    public class UserFindDTO
    {
        [DisplayName("ایمیل")]
        [MaxLength(100, ErrorMessage = "{0} باید حداکثر {1} کاراکتر باشد")]
        [EmailAddress(ErrorMessage = "لطفا یک ایمیل معتبر وارد کنید")]
        [Filter(FilterTypeEnum.EqualsIgnoreCase)]
        public string? Email { get; set; }

        [DisplayName("تلفن همراه")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "{0} باید {1} کاراکتر باشد")]
        [RegularExpression(@"^09\d*$", ErrorMessage = "{0} معتبر نیست")]
        [Filter(FilterTypeEnum.Equals)]
        public string? PhoneNumber { get; set; }

    }
}
