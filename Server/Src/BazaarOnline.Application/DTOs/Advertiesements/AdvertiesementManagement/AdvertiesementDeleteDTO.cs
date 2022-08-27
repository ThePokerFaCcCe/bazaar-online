using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BazaarOnline.Application.DTOs.Advertiesements.AdvertiesementManagement
{
    public class AdvertiesementDeleteDTO
    {
        [DisplayName("دلیل")]
        [StringLength(1000, MinimumLength = 2, ErrorMessage = "{0} باید بین {2} تا {1} کاراکتر باشد")]
        public string? Reason { get; set; }
    }
}
