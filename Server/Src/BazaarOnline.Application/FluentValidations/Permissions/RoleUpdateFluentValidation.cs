using BazaarOnline.Application.DTOs.Permissions.RoleDTOs;
using BazaarOnline.Application.Interfaces.Permissions;
using BazaarOnline.Application.ViewModels.RoleViewModels;
using FluentValidation;

namespace BazaarOnline.Application.FluentValidations.Permissions
{
    public class RoleUpdateFluentValidation : AbstractValidator<RoleUpdateDTO>
    {
        public RoleUpdateFluentValidation(IPermissionService permissionService, IRoleService roleService)
        {
            RuleFor(v => v.Permissions)
                .Must(selectedPerms =>
                {
                    var perms = permissionService.GetPermissionIds();
                    var invalidPerms = selectedPerms.Except(perms);

                    return !invalidPerms.Any();
                })
                .WithMessage("تمامی دسترسی ها معتبر نیستند");
        }
    }
}
