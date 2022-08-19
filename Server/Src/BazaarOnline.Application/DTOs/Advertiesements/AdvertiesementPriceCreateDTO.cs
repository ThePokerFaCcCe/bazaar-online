using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using BazaarOnline.Domain.Entities.Advertiesements;

namespace BazaarOnline.Application.DTOs.Advertiesements
{
    public class AdvertiesementPriceCreateDTO
    {
        [DisplayName("مبلغ")]
        public int? Value { get; set; }

        [DisplayName("توافقی")]
        public bool IsAgreement { get; set; }

        [DisplayName("نوع")]
        [Required(ErrorMessage = "این فیلد اجباری است")]
        public AdvertiesementPriceType Type { get; set; }
    }
}
