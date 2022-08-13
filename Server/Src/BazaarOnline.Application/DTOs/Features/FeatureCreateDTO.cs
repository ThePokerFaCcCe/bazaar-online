using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using BazaarOnline.Domain.Entities.Features;

namespace BazaarOnline.Application.DTOs.Features
{
    public class FeatureCreateDTO
    {
        [Required(ErrorMessage = "این فیلد اجباری است")]
        [DisplayName("نام")]
        [StringLength(64, MinimumLength = 2, ErrorMessage = "{0} باید بین {2} تا {1} کاراکتر باشد")]
        public string Title { get; set; }

        [Required(ErrorMessage = "این فیلد اجباری است")]
        public FeatureTypeEnum FeatureType { get; set; }

        [Required(ErrorMessage = "این فیلد اجباری است")]
        public bool IsRequired { get; set; }

        public FeatureEnumCreateDTO? FeatureEnum { get; set; }

        public FeatureIntegerCreateDTO? FeatureInteger { get; set; }
    }

}
