using BazaarOnline.Application.Interfaces.Permissions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BazaarOnline.Application.Securities.Attributes
{
    public class HasPermissionAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        private int _permissionId;
        private IPermissionService _permissionService;
        // => DependencyResolver.Current.GetService<IPermissionService>();

        public HasPermissionAttribute(int permissionId)
        {
            _permissionId = permissionId;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User;
            if (user.Identity.IsAuthenticated && int.TryParse(user.Identity.Name, out int userId))
            {
                _permissionService = (IPermissionService)context.HttpContext
                    .RequestServices.GetService(typeof(IPermissionService));

                if (!_permissionService.HasUserPermission(userId, _permissionId))
                {
                    context.Result = new ForbidResult(JwtBearerDefaults.AuthenticationScheme);
                }
            }
            else
            {
                context.Result = new ForbidResult(JwtBearerDefaults.AuthenticationScheme);
            }
        }
    }
}
