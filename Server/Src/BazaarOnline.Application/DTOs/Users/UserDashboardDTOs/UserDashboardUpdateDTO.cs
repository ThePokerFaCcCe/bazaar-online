using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BazaarOnline.Application.DTOs.Users.UserDashboardDTOs
{
    public class UserDashboardUpdateDTO
    {
        [Required(ErrorMessage = "این فیلد اجباری است")]
        [DisplayName("نام")]
        [StringLength(32, MinimumLength = 2, ErrorMessage = "{0} باید بین {2} تا {1} کاراکتر باشد")]
        public string FirstName { get; set; }

        [DisplayName("نام خانوادگی")]
        [StringLength(32, MinimumLength = 2, ErrorMessage = "{0} باید بین {2} تا {1} کاراکتر باشد")]
        public string LastName { get; set; }

        [DisplayName("رمز")]
        [MinLength(6, ErrorMessage = "{0} باید حداقل {1} کاراکتر باشد")]
        public string? Password { get; set; }
    }
}
