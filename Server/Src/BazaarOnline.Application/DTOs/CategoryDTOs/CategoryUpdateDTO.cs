using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BazaarOnline.Application.DTOs.CategoryDTOs
{
    public class CategoryUpdateDTO
    {
        [Required(ErrorMessage = "این فیلد اجباری است")]
        [DisplayName("نام")]
        [StringLength(64, MinimumLength = 3, ErrorMessage = "{0} باید بین {2} تا {1} کاراکتر باشد")]
        public string Title { get; set; }
        public string? Icon { get; set; }
        public int? ParentId { get; set; }
    }
}
