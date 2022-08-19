using BazaarOnline.Application.Interfaces.Advertiesements;
using BazaarOnline.Application.Interfaces.Auth;
using BazaarOnline.Application.Interfaces.Categories;
using BazaarOnline.Application.Interfaces.Features;
using BazaarOnline.Application.Interfaces.Locations;
using BazaarOnline.Application.Interfaces.Permissions;
using BazaarOnline.Application.Interfaces.Senders;
using BazaarOnline.Application.Interfaces.Users;
using BazaarOnline.Application.Services.Advertiesements;
using BazaarOnline.Application.Services.Auth;
using BazaarOnline.Application.Services.Categories;
using BazaarOnline.Application.Services.Features;
using BazaarOnline.Application.Services.Locations;
using BazaarOnline.Application.Services.Permissions;
using BazaarOnline.Application.Services.Senders;
using BazaarOnline.Application.Services.Users;
using BazaarOnline.Domain.Interfaces;
using BazaarOnline.Infra.Data.Repositories;
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
            services.AddScoped<IUserDashboardService, UserDashboardService>();
            services.AddScoped<IActiveCodeService, ActiveCodeService>();
            #endregion

            #region Permission
            services.AddScoped<IPermissionService, PermissionService>();
            services.AddScoped<IRoleService, RoleService>();
            #endregion

            #region Categories
            services.AddScoped<ICategoryService, CategoryService>();
            #endregion

            #region Locations
            services.AddScoped<ILocationService, LocationService>();
            #endregion

            #region Senders
            services.AddScoped<IEmailService, EmailService>();
            #endregion

            #region Features
            services.AddScoped<IFeatureService, FeatureService>();
            #endregion

            #region Advertiesements
            services.AddScoped<IAdvertiesementService, AdvertiesementService>();
            #endregion

            #endregion

            #region Repositories
            services.AddScoped<IRepository, Repository>();
            #endregion
        }
    }
}
