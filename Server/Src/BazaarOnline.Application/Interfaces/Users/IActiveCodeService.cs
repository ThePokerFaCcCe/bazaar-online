using BazaarOnline.Domain.Entities.Users;

namespace BazaarOnline.Application.Interfaces.Users
{
    public interface IActiveCodeService
    {
        ActiveCode? GetActiveCode(string email, string code);
        bool IsEmailActiveCodeExists(string email);
        bool IsEmailActiveCodeExists(string email, string code);
        bool IsPhoneActiveCodeExists(string phone);
        bool IsPhoneActiveCodeExists(string phone, string code);
    }
}
