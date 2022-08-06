using BazaarOnline.Application.DTOs.AuthDTOs;
using BazaarOnline.Application.DTOs.PaginationDTO;
using BazaarOnline.Application.DTOs.Users.UserDTOs;
using BazaarOnline.Application.Interfaces.Users;
using BazaarOnline.Application.Securities;
using BazaarOnline.Application.Utils.Extentions;
using BazaarOnline.Application.ViewModels.Users.UserViewModels;
using BazaarOnline.Domain.Entities.Users;
using BazaarOnline.Domain.Interfaces.Users;
using Microsoft.EntityFrameworkCore;

namespace BazaarOnline.Application.Services.Users
{
    public class UserService : IUserService
    {
        private string[] _userOrderProperties = new string[]{
            nameof(User.FirstName),
            nameof(User.LastName),
            nameof(User.CreateDate),
            nameof(User.Email),
            nameof(User.IsActive),
        };

        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void ActivateUser(User user)
        {
            user.IsActive = true;
            _userRepository.UpdateUser(user);
            _userRepository.Save();
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
            createDTO.Password = PasswordHelper.HashPassword(createDTO.Password);
            createDTO.Email = createDTO.Email.ToLower();
            createDTO.TrimStrings();

            var user = new User();
            user.FillFromObject(createDTO, ignoreNulls: false);

            _userRepository.AddUser(user);
            _userRepository.Save();

            return user;
        }

        public User CreateUser(UserRegisterDTO registerDTO)
        {
            registerDTO.Password = PasswordHelper.HashPassword(registerDTO.Password);
            registerDTO.Email = registerDTO.Email.ToLower();
            registerDTO.TrimStrings();

            var user = new User();
            user.FillFromObject(registerDTO, ignoreNulls: false);

            _userRepository.AddUser(user);
            _userRepository.Save();

            return user;
        }

        public User? FindUser(string email)
        {
            return _userRepository.GetUsers()
                .SingleOrDefault(u => u.Email == email.ToLower().Trim());
        }

        public PaginationResultDTO<UserListDetailViewModel> GetUserListDetails(
            UserFilterDTO filter, PaginationFilterDTO pagination)
        {
            var users = _userRepository.GetUsers().IgnoreQueryFilters();
            var count = users.Count();

            #region Filters
            filter.TrimStrings();

            // IsDeleted
            users = users.Where(u => u.IsDeleted == filter.IsDeleted);

            if (filter.IsActive != null)
                users = users.Where(u => u.IsActive == filter.IsActive);

            if (!string.IsNullOrEmpty(filter.Email))
                users = users.Where(u => u.Email.Contains(filter.Email.ToLower()));

            if (!string.IsNullOrEmpty(filter.Name))
                users = users.Where(
                    u => u.FirstName.Contains(filter.Name.ToLower())
                      || u.LastName.Contains(filter.Name.ToLower()));


            #endregion

            #region Ordering
            if (!string.IsNullOrEmpty(filter.OrderBy))
                users = users.OrderBy(filter.OrderBy, _userOrderProperties);
            #endregion

            #region Pagination
            users = users.Paginate(pagination);
            #endregion

            return new PaginationResultDTO<UserListDetailViewModel>
            {
                Count = count,
                Content = users.Select(u => new UserListDetailViewModel
                {
                    Id = u.Id,
                    CreateDate = u.CreateDate,
                    Email = u.Email,
                    FullName = u.FullName,
                    IsActive = u.IsActive,
                }).ToList()
            };

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

        public void SoftDeleteUser(User user)
        {
            _userRepository.SoftDeleteUser(user);
            _userRepository.Save();
        }

        public void UpdateUser(User user, UserUpdateDTO updateDTO)
        {
            if (!string.IsNullOrEmpty(updateDTO.Password))
                updateDTO.Password = PasswordHelper.HashPassword(updateDTO.Password);

            updateDTO.TrimStrings();
            user.FillFromObject(updateDTO);

            _userRepository.UpdateUser(user);
            _userRepository.Save();
        }

        public User? FindUser(int id)
        {
            return _userRepository.FindUser(id);
        }

        public UserDetailViewModel? GetUserDetail(int id)
        {
            var user = _userRepository.GetUsers()
                .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role)
                .SingleOrDefault(u => u.Id == id);
            if (user == null) return null;
            return _GetUserDetailViewModel(user);
        }

        public UserDetailViewModel? GetUserDetail(string email)
        {
            var user = _userRepository.GetUsers()
                .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role)
                .SingleOrDefault(u => u.Email == email.ToLower().Trim());
            if (user == null) return null;
            return _GetUserDetailViewModel(user);
        }

        private UserDetailViewModel _GetUserDetailViewModel(User user)
        {
            return new UserDetailViewModel
            {
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                IsActive = user.IsActive,
                IsDeleted = user.IsDeleted,
                CreateDate = user.CreateDate,
                Roles = user.UserRoles.Select(ur => new UserRoleDetailListViewModel
                {
                    Id = ur.Role.Id,
                    Title = ur.Role.Title
                }).ToList()
            };
        }

        public void UpdateUserRoles(User user, UserUpdateRoleDTO updateRoleDTO)
        {
            var roles = updateRoleDTO.Roles;
            var oldRoles = _userRepository.GetUserRoles(user)
                .Select(ur => ur.RoleId).ToList();

            var removedRoles = oldRoles.Except(roles).ToList();
            var newRoles = roles.Except(oldRoles).ToList();

            _userRepository.AddUserRoleRange(newRoles, user);
            _userRepository.DeleteUserRoleRange(removedRoles, user);
            _userRepository.Save();
        }

    }
}
