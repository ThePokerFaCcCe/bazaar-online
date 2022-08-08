namespace BazaarOnline.Application.ViewModels.Categories
{
    public class CategoryDetailViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public CategoryParentDetailViewModel? Parent { get; set; }
        public List<CategoryChildDetailViewModel> Children { get; set; }
    }
}
