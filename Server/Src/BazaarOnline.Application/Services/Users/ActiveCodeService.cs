using BazaarOnline.Application.Generators;
using BazaarOnline.Application.Interfaces.Users;
using BazaarOnline.Domain.Entities.Users;
using BazaarOnline.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BazaarOnline.Application.Services.Users
{
    public class ActiveCodeService : IActiveCodeService
    {
        private readonly IRepository _repository;

        public ActiveCodeService(IRepository repository)
        {
            _repository = repository;
        }

        public ActiveCode? GetActiveCode(string email, string code)
        {
            return _repository.GetAll<ActiveCode>()
                .Include(c => c.User)
                .SingleOrDefault(c => c.User.Email == email.ToLower() && c.Code == code);
        }

        public bool IsEmailActiveCodeExists(string email)
        {
            return _repository.GetAll<ActiveCode>()
                .Include(c => c.User)
                .Any(c => c.Type == ActiveCodeType.EmailActivation
                    && c.User.Email == email.ToLower());
        }
        public bool IsEmailActiveCodeExists(string email, string code)
        {
            return _repository.GetAll<ActiveCode>()
                .Include(c => c.User)
                .Any(c => c.Type == ActiveCodeType.EmailActivation
                    && c.User.Email == email.ToLower()
                    && c.Code == code);
        }

        public bool IsPhoneActiveCodeExists(string phone)
        {
            return _repository.GetAll<ActiveCode>()
                .Include(c => c.User)
                .Any(c => c.Type == ActiveCodeType.UserActivation
                    && c.User.PhoneNumber == phone);
        }

        public bool IsPhoneActiveCodeExists(string phone, string code)
        {
            return _repository.GetAll<ActiveCode>()
                .Include(c => c.User)
                .Any(c => c.Type == ActiveCodeType.UserActivation
                    && c.User.PhoneNumber == phone
                    && c.Code == code);
        }
    }
}
