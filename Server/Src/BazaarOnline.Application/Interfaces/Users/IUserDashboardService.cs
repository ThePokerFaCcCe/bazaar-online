using System.Security.Claims;
using BazaarOnline.Application.DTOs.Users.UserDashboardDTOs;
using BazaarOnline.Application.ViewModels.Users.UserDashboardViewModels;
using BazaarOnline.Domain.Entities.Users;

namespace BazaarOnline.Application.Interfaces.Users
{
    public interface IUserDashboardService
    {
        User? GetAuthorizedUser(ClaimsPrincipal User);
        UserDashboardDetailViewModel? GetUserDashboardDetail(int userId);
        void UpdateUser(User user, UserDashboardUpdateDTO updateDTO);

        bool IsPhoneNumberExists(string phone);
    }
}
