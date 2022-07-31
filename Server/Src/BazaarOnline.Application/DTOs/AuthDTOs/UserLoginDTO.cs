using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BazaarOnline.Application.DTOs.AuthDTOs
{
    public class UserLoginDTO
    {
        [Required(ErrorMessage = "این فیلد اجباری است")]
        [DisplayName("ایمیل")]
        [MaxLength(100, ErrorMessage = "{0} باید حداکثر {1} کاراکتر باشد")]
        [EmailAddress(ErrorMessage = "لطفا یک ایمیل معتبر وارد کنید")]
        public string Email { get; set; }

        [Required(ErrorMessage = "این فیلد اجباری است")]
        [DisplayName("رمز")]
        [MinLength(6, ErrorMessage = "{0} باید حداقل {1} کاراکتر باشد")]
        public string Password { get; set; }
    }
}
