using BazaarOnline.Application.Generators;
using BazaarOnline.Application.Interfaces.Users;
using BazaarOnline.Domain.Entities.Users;
using BazaarOnline.Domain.Interfaces;

namespace BazaarOnline.Application.Services.Users
{
    public class ActiveCodeService : IActiveCodeService
    {
        private readonly IRepositories _repositories;

        public ActiveCodeService(IRepositories repositories)
        {
            _repositories = repositories;
        }

        public ActiveCode CreateActiveCode(string email)
        {
            var activeCode = _repositories.ActiveCodes.Add(new ActiveCode
            {
                Email = email.ToLower(),
                Code = StringGenerator.GenerateActiveCode(),
                ExpireDate = DateTime.Now.AddMinutes(1)
            });

            _repositories.ActiveCodes.Save();
            return activeCode;
        }

        public ActiveCode? GetActiveCode(string email, string code)
        {
            return _repositories.ActiveCodes.GetAll()
                .SingleOrDefault(c => c.Email == email.ToLower() && c.Code == code);
        }

        public bool IsActiveCodeExists(string email)
        {
            return _repositories.ActiveCodes.GetAll()
                .Any(c => c.Email == email.ToLower());
        }
        public bool IsActiveCodeExists(string email, string code)
        {
            return _repositories.ActiveCodes.GetAll()
                .Any(c => c.Email == email.ToLower() && c.Code == code);
        }
    }
}
