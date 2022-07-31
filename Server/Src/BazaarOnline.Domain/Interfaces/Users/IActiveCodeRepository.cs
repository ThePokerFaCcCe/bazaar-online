using BazaarOnline.Domain.Entities.Users;

namespace BazaarOnline.Domain.Interfaces.Users
{
    public interface IActiveCodeRepository
    {
        ActiveCode AddActiveCode(ActiveCode activeCode);
        IQueryable<ActiveCode> GetActiveCodes();

        void Save();
    }
}
