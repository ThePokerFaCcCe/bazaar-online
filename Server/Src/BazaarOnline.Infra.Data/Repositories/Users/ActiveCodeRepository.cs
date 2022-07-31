using BazaarOnline.Domain.Entities.Users;
using BazaarOnline.Domain.Interfaces.Users;
using BazaarOnline.Infra.Data.Contexts;

namespace BazaarOnline.Infra.Data.Repositories.Users
{
    public class ActiveCodeRepository : IActiveCodeRepository
    {
        private readonly BazaarDbContext _context;

        public ActiveCodeRepository(BazaarDbContext context)
        {
            _context = context;
        }

        public ActiveCode AddActiveCode(ActiveCode activeCode)
        {
            return _context.ActiveCodes.Add(activeCode).Entity;
        }

        public IQueryable<ActiveCode> GetActiveCodes()
        {
            return _context.ActiveCodes.AsQueryable();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
