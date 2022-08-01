using BazaarOnline.Application.Interfaces.Senders;
using BazaarOnline.Domain.Entities.Users;
using Microsoft.Extensions.Logging;

namespace BazaarOnline.Application.Services.Senders
{

    public class EmailService : IEmailService
    {
        private readonly ILogger<EmailService> _logger;

        public EmailService(ILogger<EmailService> logger)
        {
            _logger = logger;
        }

        public void SendActiveCode(User user, ActiveCode activeCode)
        {
            var email = user.Email;
            var emailText = $"سلام {user.FullName}. به بازار آنلاین خوش اومدی. کد فعالسازی: {activeCode.Code}";
            var subject = "فعالسازی حساب بازار آنلاین";

            SendEmail(email, subject, emailText);
        }

        public void SendEmail(string to, string subject, string body)
        {
            #region Send SMTP Email

            // MailMessage mail = new MailMessage();
            // SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
            // smtpServer.UseDefaultCredentials = false;

            // mail.From = new MailAddress("matin.khaleghi.nezhad@gmail.com", "Bazaar");
            // mail.To.Add(to);
            // mail.Subject = subject;
            // mail.Body = body;
            // mail.IsBodyHtml = true;

            // smtpServer.Port = 587;
            // smtpServer.Credentials = new System.Net.NetworkCredential("matin.khaleghi.nezhad@gmail.com", "MaTiNaM Dige!");
            // smtpServer.EnableSsl = true;

            // smtpServer.Send(mail);

            #endregion

            _logger.LogInformation(
                $"Sending Email\n---\nReceiver: {to}\nContent:\n\t{body}\n---\n");
        }
    }
}
