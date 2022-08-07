namespace BazaarOnline.Domain.Entities.Categories
{
    public class Category
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int? ParentId { get; set; }

        #region Relations

        public Category ParentCategory { get; set; }
        public List<Category> ChildCategories { get; set; }

        #endregion

    }
}
