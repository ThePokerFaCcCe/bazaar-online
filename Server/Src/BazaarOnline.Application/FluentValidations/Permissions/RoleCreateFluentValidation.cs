using BazaarOnline.Application.DTOs.Permissions.RoleDTOs;
using BazaarOnline.Application.Interfaces.Permissions;
using FluentValidation;

namespace BazaarOnline.Application.FluentValidations.Permissions
{
    public class RoleCreateFluentValidation : AbstractValidator<RoleCreateDTO>
    {
        public RoleCreateFluentValidation(IPermissionService permissionService)
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
