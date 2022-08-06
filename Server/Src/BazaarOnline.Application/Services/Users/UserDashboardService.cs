using System.Security.Claims;
using BazaarOnline.Application.DTOs.Users.UserDashboardDTOs;
using BazaarOnline.Application.Interfaces.Users;
using BazaarOnline.Application.Securities;
using BazaarOnline.Application.Utils.Extentions;
using BazaarOnline.Application.ViewModels.Users.UserDashboardViewModels;
using BazaarOnline.Domain.Entities.Users;
using BazaarOnline.Domain.Interfaces.Users;

namespace BazaarOnline.Application.Services.Users
{
    public class UserDashboardService : IUserDashboardService
    {
        private readonly IUserRepository _userRepository;

        public UserDashboardService(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }
        public User? GetAuthorizedUser(ClaimsPrincipal User)
        {
            if (int.TryParse(User.Identity.Name, out int userId))
                return _userRepository.FindUser(userId);
            return null;

        }

        public bool IsPhoneNumberExists(string phone)
        {
            return _userRepository.GetUsers()
                .Any(u => u.PhoneNumber == phone);
        }

        public UserDashboardDetailViewModel? GetUserDashboardDetail(int userId)
        {
            var user = _userRepository.FindUser(userId);
            if (user == null) return null;

            var result = new UserDashboardDetailViewModel();
            return result.FillFromObject(user);
        }

        public void UpdateUser(User user, UserDashboardUpdateDTO updateDTO)
        {
            if (!string.IsNullOrEmpty(updateDTO.Password))
                updateDTO.Password = PasswordHelper.HashPassword(updateDTO.Password);

            updateDTO.TrimStrings();
            user.FillFromObject(updateDTO, ignoreNulls: true);

            _userRepository.UpdateUser(user);
            _userRepository.Save();
        }
    }
}
