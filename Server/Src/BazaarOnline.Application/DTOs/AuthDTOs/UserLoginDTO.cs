using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BazaarOnline.Application.DTOs.AuthDTOs
{
    public class UserLoginDTO
    {
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
