using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace BazaarOnline.Application.DTOs.Advertiesements
{
    public class AdvertiesementCreateDTO
    {
        [Required(ErrorMessage = "این فیلد اجباری است")]
        [DisplayName("موضوع")]
        [StringLength(64, MinimumLength = 2, ErrorMessage = "{0} باید بین {2} تا {1} کاراکتر باشد")]
        public string Title { get; set; }

        [Required(ErrorMessage = "این فیلد اجباری است")]
        [DisplayName("توضیحات")]
        [StringLength(1000, MinimumLength = 2, ErrorMessage = "{0} باید بین {2} تا {1} کاراکتر باشد")]
        public string Description { get; set; }

        [Required(ErrorMessage = "این فیلد اجباری است")]
        [DisplayName("آدرس")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "{0} باید بین {2} تا {1} کاراکتر باشد")]
        public string? Address { get; set; }

        [Required(ErrorMessage = "این فیلد اجباری است")]
        public double Longitude { get; set; }

        [Required(ErrorMessage = "این فیلد اجباری است")]
        public double Latitude { get; set; }

        public bool IsChatOnly { get; set; } = false;

        [Required(ErrorMessage = "این فیلد اجباری است")]
        [DisplayName("دسته بندی")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "این فیلد اجباری است")]
        [DisplayName("استان")]
        public int CityId { get; set; }

        [Required(ErrorMessage = "این فیلد اجباری است")]
        public AdvertiesementPriceCreateDTO AdvertiesementPrice { get; set; }

        public List<AdvertiesementFeatureValueCreateDTO>? AdvertiesementFeatureValues { get; set; }
            = new List<AdvertiesementFeatureValueCreateDTO>();

        public List<IFormFile>? AdvertiesementPictures { get; set; }
            = new List<IFormFile>();
    }
}
