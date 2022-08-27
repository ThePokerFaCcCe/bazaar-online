using BazaarOnline.Domain.Entities.Users;

namespace BazaarOnline.Application.Interfaces.Senders
{
    public interface ISMSService
    {
        bool SendActiveCode(User user, ActiveCode activeCode);
        bool SendSMS(string phoneNumber, string text);
    }
}
