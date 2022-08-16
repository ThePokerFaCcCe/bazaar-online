using BazaarOnline.Application.Generators;
using BazaarOnline.Application.Interfaces.Users;
using BazaarOnline.Domain.Entities.Users;
using BazaarOnline.Domain.Interfaces;

namespace BazaarOnline.Application.Services.Users
{
    public class ActiveCodeService : IActiveCodeService
    {
        private readonly IRepository _repository;

        public ActiveCodeService(IRepository repository)
        {
            _repository = repository;
        }

        public ActiveCode CreateActiveCode(string email)
        {
            var activeCode = _repository.Add<ActiveCode>(new ActiveCode
            {
                Email = email.ToLower(),
                Code = StringGenerator.GenerateActiveCode(),
                ExpireDate = DateTime.Now.AddMinutes(1)
            });

            _repository.Save();
            return activeCode;
        }

        public ActiveCode? GetActiveCode(string email, string code)
        {
            return _repository.GetAll<ActiveCode>()
                .SingleOrDefault(c => c.Email == email.ToLower() && c.Code == code);
        }

        public bool IsActiveCodeExists(string email)
        {
            return _repository.GetAll<ActiveCode>()
                .Any(c => c.Email == email.ToLower());
        }
        public bool IsActiveCodeExists(string email, string code)
        {
            return _repository.GetAll<ActiveCode>()
                .Any(c => c.Email == email.ToLower() && c.Code == code);
        }
    }
}
