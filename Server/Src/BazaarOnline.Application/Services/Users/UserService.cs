using BazaarOnline.Application.DTOs.AuthDTOs;
using BazaarOnline.Application.DTOs.PaginationDTO;
using BazaarOnline.Application.DTOs.Users.UserDTOs;
using BazaarOnline.Application.Filters;
using BazaarOnline.Application.Interfaces.Users;
using BazaarOnline.Application.Securities;
using BazaarOnline.Application.Utils.Extentions;
using BazaarOnline.Application.ViewModels.Users.UserViewModels;
using BazaarOnline.Domain.Entities.Permissions;
using BazaarOnline.Domain.Entities.Users;
using BazaarOnline.Domain.Interfaces;
using BazaarOnline.Infra.Data.Seeds.DefaultDatas;
using Microsoft.EntityFrameworkCore;

namespace BazaarOnline.Application.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IRepository _repository;

        public UserService(IRepository repository)
        {
            _repository = repository;
        }

        public void ActivateUser(User user)
        {
            user.IsActive = true;
            _repository.Update<User>(user);
            _repository.Save();
        }

        public bool ComparePassword(User user, string password)
        {
            return PasswordHelper.VerifyPassword(password, user.Password);
        }

        public bool ComparePassword(string email, string password)
        {
            var foundPassword = _repository.GetAll<User>()
                .Where(u => u.Email == email.ToLower())
                .Select(u => u.Password).SingleOrDefault();

            if (string.IsNullOrEmpty(foundPassword)) return false;

            return PasswordHelper.VerifyPassword(password, foundPassword);
        }

        public User CreateUser(UserCreateDTO createDTO)
        {
            createDTO.Password = PasswordHelper.HashPassword(createDTO.Password);
            createDTO.Email = createDTO.Email.ToLower();
            createDTO.Roles.Add(DefaultRoles.NormalUser.Id);
            createDTO.TrimStrings();

            var user = new User();
            user.FillFromObject(createDTO);
            user.UserRoles = new List<UserRole>();
            user.UserRoles.AddRange(createDTO.Roles.Distinct().Select(r => new UserRole { RoleId = r }));
            _repository.Add<User>(user);
            _repository.Save();

            return user;
        }

        public User CreateUser(UserRegisterDTO registerDTO)
        {
            registerDTO.Password = PasswordHelper.HashPassword(registerDTO.Password);
            registerDTO.Email = registerDTO.Email.ToLower();
            registerDTO.TrimStrings();

            var user = new User();
            user.FillFromObject(registerDTO);
            user.UserRoles = new List<UserRole>();
            user.UserRoles.Add(new UserRole { RoleId = DefaultRoles.NormalUser.Id });

            _repository.Add<User>(user);
            _repository.Save();

            return user;
        }

        public User? FindUser(string email)
        {
            return _repository.GetAll<User>()
                .SingleOrDefault(u => u.Email == email.ToLower().Trim());
        }

        public PaginationResultDTO<UserListDetailViewModel> GetUserListDetails(
            UserFilterDTO filter, PaginationFilterDTO pagination)
        {
            var users = _repository.GetAll<User>().IgnoreQueryFilters();

            #region Filters
            filter.TrimStrings();
            users = users.Filter(filter);
            #endregion


            #region Pagination
            var count = users.Count();
            users = users.Paginate(pagination);
            #endregion

            return new PaginationResultDTO<UserListDetailViewModel>
            {
                Count = count,
                Content = users.Select(u =>
                    ModelHelper.CreateAndFillFromObject
                        <UserListDetailViewModel, User>(u, false)
                ).ToList()
            };

        }

        public bool IsEmailExists(string email)
        {
            return _repository.GetAll<User>()
                .Any(u => u.Email == email.ToLower());
        }

        public bool IsInactiveUserExists(string email)
        {
            return _repository.GetAll<User>()
                .Any(u => (!u.IsActive && u.Email == email.ToLower()));
        }

        public bool IsPhoneNumberExists(string phone)
        {
            return _repository.GetAll<User>()
                .Any(u => u.PhoneNumber == phone);
        }

        public void SoftDeleteUser(User user)
        {
            user.IsDeleted = true;
            _repository.Update<User>(user);
            _repository.Save();
        }

        public void UpdateUser(User user, UserUpdateDTO updateDTO)
        {
            if (!string.IsNullOrEmpty(updateDTO.Password))
                updateDTO.Password = PasswordHelper.HashPassword(updateDTO.Password);

            updateDTO.TrimStrings();
            user.FillFromObject(updateDTO, ignoreNulls: true);

            _repository.Update<User>(user);
            _repository.Save();
        }

        public User? FindUser(int id)
        {
            return _repository.Get<User>(id);
        }

        public UserDetailViewModel? GetUserDetail(int id)
        {
            var user = _repository.GetAll<User>()
                .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role)
                .SingleOrDefault(u => u.Id == id);
            if (user == null) return null;
            return _GetUserDetailViewModel(user);
        }

        public UserDetailViewModel? GetUserDetail(string email)
        {
            var user = _repository.GetAll<User>()
                .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role)
                .SingleOrDefault(u => u.Email == email.ToLower().Trim());
            if (user == null) return null;
            return _GetUserDetailViewModel(user);
        }

        private UserDetailViewModel _GetUserDetailViewModel(User user)
        {
            var userDetail = ModelHelper.CreateAndFillFromObject
                <UserDetailViewModel, User>(user);

            userDetail.Roles = user.UserRoles.Select(ur =>
                ModelHelper.CreateAndFillFromObject
                    <UserRoleDetailListViewModel, Role>(ur.Role)
            ).ToList();

            return userDetail;

        }

        public void UpdateUserRoles(User user, UserUpdateRoleDTO updateRoleDTO)
        {
            var userRoles = _repository.GetAll<UserRole>()
                .Where(ur => ur.UserId == user.Id);


            var newRoles = updateRoleDTO.Roles
                .Except(userRoles.Select(ur => ur.RoleId))
                .Select(r => new UserRole
                {
                    RoleId = r,
                    UserId = user.Id,
                });
            var removedRoles = userRoles
                .Where(ur => !updateRoleDTO.Roles.Contains(ur.RoleId));

            _repository.AddRange<UserRole>(newRoles);
            _repository.RemoveRange<UserRole>(removedRoles);
            _repository.Save();
        }

    }
}
