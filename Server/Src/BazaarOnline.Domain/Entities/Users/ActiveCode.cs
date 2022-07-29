namespace BazaarOnline.Domain.Entities.Users
{
    public class ActiveCode
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Code { get; set; }

        public DateTime ExpireDate { get; set; }
    }
}
