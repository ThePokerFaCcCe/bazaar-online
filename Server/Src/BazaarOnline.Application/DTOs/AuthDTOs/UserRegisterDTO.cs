using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BazaarOnline.Application.DTOs.AuthDTOs
{
    public class UserRegisterDTO
    {
        [Required(ErrorMessage = "این فیلد اجباری است")]
        [DisplayName("نام")]
        [StringLength(32, MinimumLength = 2, ErrorMessage = "{0} باید بین {2} تا {1} کاراکتر باشد")]
        public string FirstName { get; set; }

        [DisplayName("نام خانوادگی")]
        [StringLength(32, MinimumLength = 2, ErrorMessage = "{0} باید بین {2} تا {1} کاراکتر باشد")]
        public string? LastName { get; set; }

        [DisplayName("ایمیل")]
        [MaxLength(100, ErrorMessage = "{0} باید حداکثر {1} کاراکتر باشد")]
        [EmailAddress(ErrorMessage = "لطفا یک ایمیل معتبر وارد کنید")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "این فیلد اجباری است")]
        [DisplayName("تلفن همراه")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "{0} باید {1} کاراکتر باشد")]
        [RegularExpression(@"^09\d*$", ErrorMessage = "{0} معتبر نیست")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "این فیلد اجباری است")]
        [DisplayName("رمز")]
        [MinLength(6, ErrorMessage = "{0} باید حداقل {1} کاراکتر باشد")]
        public string Password { get; set; }
    }
}
