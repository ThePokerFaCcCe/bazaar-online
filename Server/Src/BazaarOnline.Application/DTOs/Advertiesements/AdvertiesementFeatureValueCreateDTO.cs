using System.ComponentModel.DataAnnotations;

namespace BazaarOnline.Application.DTOs.Advertiesements
{
    public class AdvertiesementFeatureValueCreateDTO
    {
        [Required(ErrorMessage = "این فیلد اجباری است")]
        [StringLength(64, ErrorMessage = "باید بین {2} تا {1} کاراکتر باشد")]
        public string Value { get; set; }

        [Required(ErrorMessage = "این فیلد اجباری است")]
        public int FeatureId { get; set; }
    }
}
