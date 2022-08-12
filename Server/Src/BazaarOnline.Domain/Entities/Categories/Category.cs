using BazaarOnline.Domain.Entities.Advertiesements;

namespace BazaarOnline.Domain.Entities.Categories
{
    public class Category
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int? ParentId { get; set; }

        public string? Icon { get; set; }

        #region Relations

        public Category ParentCategory { get; set; }
        public List<Category> ChildCategories { get; set; }

        public List<Advertiesement> Advertiesements { get; set; }
        public List<CategoryFeature> CategoryFeatures { get; set; }

        #endregion

    }
}
