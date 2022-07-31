using BazaarOnline.Application.Generators;
using BazaarOnline.Application.Interfaces.Users;
using BazaarOnline.Domain.Entities.Users;
using BazaarOnline.Domain.Interfaces.Users;

namespace BazaarOnline.Application.Services.Users
{
    public class ActiveCodeService : IActiveCodeService
    {
        private IActiveCodeRepository _activeCodeRepository;

        public ActiveCodeService(IActiveCodeRepository activeCodeRepository)
        {
            _activeCodeRepository = activeCodeRepository;
        }

        public ActiveCode CreateActiveCode(string email)
        {
            var activeCode = _activeCodeRepository.AddActiveCode(new ActiveCode
            {
                Email = email.ToLower(),
                Code = StringGenerator.GenerateActiveCode(),
                ExpireDate = DateTime.Now.AddMinutes(1)
            });

            _activeCodeRepository.Save();
            return activeCode;
        }

        public ActiveCode? GetActiveCode(string email, string code)
        {
            return _activeCodeRepository.GetActiveCodes()
                .SingleOrDefault(c => c.Email == email.ToLower() && c.Code == code);
        }

        public bool IsActiveCodeExists(string email)
        {
            return _activeCodeRepository.GetActiveCodes()
                .Any(c => c.Email == email.ToLower());
        }
        public bool IsActiveCodeExists(string email, string code)
        {
            return _activeCodeRepository.GetActiveCodes()
                .Any(c => c.Email == email.ToLower() && c.Code == code);
        }
    }
}
