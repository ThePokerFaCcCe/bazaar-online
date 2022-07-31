using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BazaarOnline.Application.DTOs.AuthDTOs
{
    public class ActivateUserEmailDTO
    {
        [Required(ErrorMessage = "این فیلد اجباری است")]
        [MaxLength(64)]
        public string Code { get; set; }

        [Required(ErrorMessage = "این فیلد اجباری است")]
        [DisplayName("ایمیل")]
        [MaxLength(100, ErrorMessage = "{0} باید حداکثر {1} کاراکتر باشد")]
        [EmailAddress(ErrorMessage = "لطفا یک ایمیل معتبر وارد کنید")]
        public string Email { get; set; }
    }
}
