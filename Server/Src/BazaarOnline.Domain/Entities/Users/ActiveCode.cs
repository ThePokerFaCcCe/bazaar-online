namespace BazaarOnline.Domain.Entities.Users
{
    public class ActiveCode
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string Code { get; set; }

        public DateTime ExpireDate { get; set; }

        #region Relations
        public User User { get; set; }
        #endregion
    }
}
