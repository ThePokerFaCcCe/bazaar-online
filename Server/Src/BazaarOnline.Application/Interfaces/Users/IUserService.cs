using BazaarOnline.Application.DTOs.AuthDTOs;
using BazaarOnline.Application.DTOs.PaginationDTO;
using BazaarOnline.Application.DTOs.Users.UserDTOs;
using BazaarOnline.Application.ViewModels.Users.UserViewModels;
using BazaarOnline.Domain.Entities.Users;

namespace BazaarOnline.Application.Interfaces.Users
{
    public interface IUserService
    {
        PaginationResultDTO<UserListDetailViewModel> GetUserListDetails(
            UserFilterDTO filter, PaginationFilterDTO pagination);

        UserDetailViewModel? GetUserDetail(int id);
        UserDetailViewModel? GetUserDetail(string email);

        User CreateUser(UserCreateDTO createDTO);
        public User CreateUser(UserRegisterDTO registerDTO);
        User? FindUser(string email);
        User? FindUser(int id);
        void UpdateUser(User user, UserUpdateDTO updateDTO);
        /// <summary>
        /// Set User.IsDeleted Property to true
        /// </summary>
        /// <param name="user">User to soft delete</param>
        void SoftDeleteUser(User user);

        bool ComparePassword(User user, string password);
        bool ComparePassword(string email, string password);
        void ActivateUser(User user);
        bool IsEmailExists(string email);
        bool IsInactiveUserExists(string email);
        bool IsPhoneNumberExists(string phone);

        #region UserRoles

        void UpdateUserRoles(User user, UserUpdateRoleDTO updateRoleDTO);

        #endregion
    }
}
