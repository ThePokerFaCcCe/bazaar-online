namespace BazaarOnline.Application.ViewModels.Categories
{
    public class CategoryParentDetailViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Icon { get; set; }
        public int? ParentId { get; set; }
    }
}
