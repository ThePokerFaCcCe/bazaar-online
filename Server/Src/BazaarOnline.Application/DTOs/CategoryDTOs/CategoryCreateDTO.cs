using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BazaarOnline.Application.DTOs.CategoryDTOs
{
    public class CategoryCreateDTO
    {
        [Required(ErrorMessage = "این فیلد اجباری است")]
        [DisplayName("نام")]
        [StringLength(64, MinimumLength = 3, ErrorMessage = "{0} باید بین {2} تا {1} کاراکتر باشد")]
        public string Title { get; set; }
        public string? Icon { get; set; } = null;
        public int? ParentId { get; set; } = null;
        public List<CategoryChildCreateDTO> Children { get; set; }
            = new List<CategoryChildCreateDTO>();
    }

    public class CategoryChildCreateDTO
    {
        [Required(ErrorMessage = "این فیلد اجباری است")]
        [DisplayName("نام")]
        [StringLength(64, MinimumLength = 3, ErrorMessage = "{0} باید بین {2} تا {1} کاراکتر باشد")]
        public string Title { get; set; }
        public string? Icon { get; set; } = null;
    }
}
