using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BazaarOnline.Application.DTOs.Features
{
    public class FeatureEnumCreateDTO
    {
        [Required(ErrorMessage = "این فیلد اجباری است")]
        [DisplayName("نام")]
        [StringLength(64, MinimumLength = 2, ErrorMessage = "{0} باید بین {2} تا {1} کاراکتر باشد")]
        public string Name { get; set; }

        [Required(ErrorMessage = "این فیلد اجباری است")]
        public List<FeatureEnumValueCreateDTO> FeatureEnumValues { get; set; }

    }

    public class FeatureEnumValueCreateDTO
    {
        [Required(ErrorMessage = "این فیلد اجباری است")]
        [DisplayName("مقدار")]
        [StringLength(64, MinimumLength = 2, ErrorMessage = "{0} باید بین {2} تا {1} کاراکتر باشد")]
        public string Value { get; set; }
    }


}
