using BazaarOnline.Domain.Entities.Users;

namespace BazaarOnline.Application.Interfaces.Senders
{
    public interface IEmailService
    {
        void SendActiveCode(User user, ActiveCode activeCode);
        void SendEmail(string to, string subject, string body);
    }
}
