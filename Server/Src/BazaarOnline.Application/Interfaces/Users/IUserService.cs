using BazaarOnline.Application.DTOs.Users.UserDTOs;
using BazaarOnline.Application.ViewModels.Users.UserViewModels;
using BazaarOnline.Domain.Entities.Users;

namespace BazaarOnline.Application.Interfaces.Users
{
    public interface IUserService
    {
        List<UserListDetailViewModel> GetUserListDetails();
        User CreateUser(UserCreateDTO createDTO);
        User? FindUser(string email);
        bool ComparePassword(User user, string password);
        bool ComparePassword(string email, string password);
        void UpdateUser(User user);
        bool IsEmailExists(string email);
        bool IsInactiveUserExists(string email);
        bool IsPhoneNumberExists(string phone);
    }
}
