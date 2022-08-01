using BazaarOnline.Application.DTOs.Users.UserDTOs;
using BazaarOnline.Application.Interfaces.Users;
using BazaarOnline.Application.Securities;
using BazaarOnline.Application.ViewModels.Users.UserViewModels;
using BazaarOnline.Domain.Entities.Users;
using BazaarOnline.Domain.Interfaces.Users;

namespace BazaarOnline.Application.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void ActivateUser(User user)
        {
            user.IsActive = true;
            UpdateUser(user);
        }

        public bool ComparePassword(User user, string password)
        {
            return PasswordHelper.VerifyPassword(password, user.Password);
        }

        public bool ComparePassword(string email, string password)
        {
            var foundPassword = _userRepository.GetUsers()
                .Where(u => u.Email == email.ToLower())
                .Select(u => u.Password).SingleOrDefault();

            if (string.IsNullOrEmpty(foundPassword)) return false;

            return PasswordHelper.VerifyPassword(password, foundPassword);
        }

        public User CreateUser(UserCreateDTO createDTO)
        {
            var user = _userRepository.AddUser(new User
            {
                Email = createDTO.Email.ToLower(),
                FirstName = createDTO.FirstName,
                LastName = createDTO.LastName,
                PhoneNumber = createDTO.PhoneNumber,
                Password = PasswordHelper.HashPassword(createDTO.Password),
            });
            _userRepository.Save();

            return user;
        }

        public User? FindUser(string email)
        {
            return _userRepository.GetUsers()
                .SingleOrDefault(u => u.Email == email.ToLower());
        }

        public List<UserListDetailViewModel> GetUserListDetails()
        {
            throw new NotImplementedException();
        }

        public bool IsEmailExists(string email)
        {
            return _userRepository.GetUsers()
                .Any(u => u.Email == email.ToLower());
        }

        public bool IsInactiveUserExists(string email)
        {
            return _userRepository.GetUsers()
                .Any(u => (!u.IsActive && u.Email == email.ToLower()));
        }

        public bool IsPhoneNumberExists(string phone)
        {
            return _userRepository.GetUsers()
                .Any(u => u.PhoneNumber == phone);
        }

        public void UpdateUser(User user)
        {
            _userRepository.UpdateUser(user);
            _userRepository.Save();
        }
    }
}
