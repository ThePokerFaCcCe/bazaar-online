using BazaarOnline.Domain.Entities.Users;
using Microsoft.Extensions.Logging;

namespace BazaarOnline.Application.Senders
{
    public class EmailSender
    {
        public static void SendActiveCode(User user, ActiveCode activeCode)
        {
            var email = user.Email;
            var emailText = $"سلام {user.FullName}. به بازار آنلاین خوش اومدی. کد فعالسازی: {activeCode.Code}";

            SendEmail(email, emailText);
        }

        public static void SendEmail(string email, string text)
        {
            System.Console.WriteLine(
                $"Sending Email\n---\nReceiver: {email}\nContent:\n\t{text}\n---\n");
        }
    }
}
