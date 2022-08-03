using BazaarOnline.Application.Interfaces.Auth;
using BazaarOnline.Application.Interfaces.Permissions;
using BazaarOnline.Application.Interfaces.Senders;
using BazaarOnline.Application.Interfaces.Users;
using BazaarOnline.Application.Services.Auth;
using BazaarOnline.Application.Services.Permissions;
using BazaarOnline.Application.Services.Senders;
using BazaarOnline.Application.Services.Users;
using BazaarOnline.Domain.Interfaces.Permissions;
using BazaarOnline.Domain.Interfaces.Users;
using BazaarOnline.Infra.Data.Repositories.Permissions;
using BazaarOnline.Infra.Data.Repositories.Users;
using Microsoft.Extensions.DependencyInjection;

namespace BazaarOnline.Infra.IoC
{
    public class DependencyContainer
    {
        public static void RegisterService(IServiceCollection services)
        {
            #region Services
            services.AddScoped<IAuthService, AuthService>();

            #region Users
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IActiveCodeService, ActiveCodeService>();
            #endregion

            #region Permission
            services.AddScoped<IPermissionService, PermissionService>();
            services.AddScoped<IRoleService, RoleService>();
            #endregion

            #region Senders
            services.AddScoped<IEmailService, EmailService>();
            #endregion

            #endregion

            #region Repositories

            #region Users
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IActiveCodeRepository, ActiveCodeRepository>();
            #endregion

            #region Permission
            services.AddScoped<IPermissionRepository, PermissionRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            #endregion

            #endregion
        }
    }
}
