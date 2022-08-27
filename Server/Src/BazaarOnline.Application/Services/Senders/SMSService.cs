using BazaarOnline.Application.Interfaces.Senders;
using BazaarOnline.Domain.Entities.Users;
using Microsoft.Extensions.Logging;

namespace BazaarOnline.Application.Services.Senders
{
    public class SMSService : ISMSService
    {
        private readonly ILogger<SMSService> _logger;

        public SMSService(ILogger<SMSService> logger)
        {
            _logger = logger;
        }

        public bool SendActiveCode(User user, ActiveCode activeCode)
        {
            var smsText = $"سلام {user.FullName}. به بازار آنلاین خوش اومدی. کد فعالسازی: {activeCode.Code}";

            return SendSMS(user.PhoneNumber, smsText);
        }


        public bool SendSMS(string phoneNumber, string text)
        {
            _logger.LogInformation(
                $"Sending SMS\n---\nReceiver: {phoneNumber}\nContent:\n\t{text}\n---\n");
            return true;
        }
    }
}
