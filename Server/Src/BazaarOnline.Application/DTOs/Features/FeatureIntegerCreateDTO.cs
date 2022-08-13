using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BazaarOnline.Application.DTOs.Features
{
    public class FeatureIntegerCreateDTO
    {
        [Required(ErrorMessage = "این فیلد اجباری است")]
        [DisplayName("نام")]
        [StringLength(64, MinimumLength = 2, ErrorMessage = "{0} باید بین {2} تا {1} کاراکتر باشد")]
        public string Name { get; set; }

        public long MinimumValue { get; set; }

        public long MaximumValue { get; set; }
    }

}
