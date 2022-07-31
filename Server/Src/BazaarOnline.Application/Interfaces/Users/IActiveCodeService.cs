using BazaarOnline.Domain.Entities.Users;

namespace BazaarOnline.Application.Interfaces.Users
{
    public interface IActiveCodeService
    {
        ActiveCode CreateActiveCode(string email);
        ActiveCode? GetActiveCode(string email, string code);
        bool IsActiveCodeExists(string email);
        bool IsActiveCodeExists(string email, string code);
    }
}
