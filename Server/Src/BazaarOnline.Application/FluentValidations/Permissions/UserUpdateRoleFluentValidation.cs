using BazaarOnline.Application.DTOs.Users.UserDTOs;
using BazaarOnline.Application.Interfaces.Permissions;
using FluentValidation;

namespace BazaarOnline.Application.FluentValidations.Permissions
{
    public class UserUpdateRoleFluentValidation : AbstractValidator<UserUpdateRoleDTO>
    {
        public UserUpdateRoleFluentValidation(IRoleService roleService)
        {
            RuleFor(v => v.Roles).Must(roles =>
            {
                var allRoles = roleService.GetRoleIds();
                var invalidRoles = roles.Except(allRoles);

                return !invalidRoles.Any();
            }).WithMessage("تمامی نقش ها معتبر نیستند");
        }
    }
}
