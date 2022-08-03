using BazaarOnline.Application.Interfaces.Permissions;
using BazaarOnline.Application.ViewModels.RoleViewModels;
using FluentValidation;

namespace BazaarOnline.Application.FluentValidations.Permissions
{
    public class RoleCreateFluentValidation : AbstractValidator<RoleCreateViewModel>
    {
        public RoleCreateFluentValidation(IPermissionService permissionService, IRoleService roleService)
        {
            RuleFor(v => v.Title)
                .Must(t => !roleService.IsRoleExists(t))
                .WithMessage(v => $"نقش با نام {v.Title} وجود دارد")
                .DependentRules(() =>
                {
                    RuleFor(v => v.Permissions)
                        .Must(selectedPerms =>
                        {
                            var perms = permissionService.GetPermissionIds();
                            var invalidPerms = selectedPerms.Except(perms);

                            return !invalidPerms.Any();
                        })
                        .WithMessage("تمامی دسترسی ها معتبر نیستند");
                });

        }
    }
}
