using System.ComponentModel.DataAnnotations;

namespace BazaarOnline.Application.DTOs.CategoryDTOs
{
    public class CategoryFeatureAddDTO
    {
        [Required]
        public List<int> Features { get; set; } = new List<int>();
    }
}
