using BazaarOnline.Domain.Entities.Categories;
using BazaarOnline.Domain.Entities.Permissions;
using BazaarOnline.Domain.Entities.Users;
using BazaarOnline.Infra.Data.FluentConfigs;
using BazaarOnline.Infra.Data.Seeds;
using Microsoft.EntityFrameworkCore;

namespace BazaarOnline.Infra.Data.Contexts
{
    public class BazaarDbContext : DbContext
    {
        public BazaarDbContext(DbContextOptions<BazaarDbContext> options) : base(options) { }

        #region DB Sets

        #region Users

        public DbSet<User> Users { get; set; }
        public DbSet<ActiveCode> ActiveCodes { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        #endregion

        #region Permissions

        public DbSet<Permission> Permissions { get; set; }
        public DbSet<PermissionGroup> PermissionGroups { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }

        #endregion

        #region Categories

        public DbSet<Category> Categories { get; set; }

        #endregion

        #endregion

        protected override void OnModelCreating(ModelBuilder builder)
        {
            #region FluentConfigs

            builder.ApplyConfigurationsFromAssembly(typeof(UserFluentConfigs).Assembly);

            #endregion

            #region Seed

            builder.SeedPermissions();

            #endregion

        }
    }
}
