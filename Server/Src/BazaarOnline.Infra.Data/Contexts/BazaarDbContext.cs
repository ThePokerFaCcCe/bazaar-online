using BazaarOnline.Domain.Entities.Advertiesements;
using BazaarOnline.Domain.Entities.Categories;
using BazaarOnline.Domain.Entities.Features;
using BazaarOnline.Domain.Entities.Locations;
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
        public DbSet<CategoryFeature> CategoryFeatures { get; set; }

        #endregion

        #region Locations

        public DbSet<City> Cities { get; set; }

        #endregion

        #region Advertiesements

        public DbSet<Advertiesement> Advertiesements { get; set; }
        public DbSet<AdvertiesementFeatureValue> AdvertiesementFeatureValues { get; set; }
        public DbSet<AdvertiesementPicture> AdvertiesementPictures { get; set; }
        public DbSet<AdvertiesementPrice> AdvertiesementPrice { get; set; }

        #endregion

        #region Features

        public DbSet<Feature> Features { get; set; }
        public DbSet<FeatureEnum> FeatureEnums { get; set; }
        public DbSet<FeatureEnumValue> FeatureEnumValues { get; set; }
        public DbSet<FeatureInteger> FeatureIntegers { get; set; }

        #endregion

        #endregion

        protected override void OnModelCreating(ModelBuilder builder)
        {
            #region FluentConfigs

            builder.ApplyConfigurationsFromAssembly(typeof(UserFluentConfigs).Assembly);

            #endregion

            #region Seed

            builder.SeedPermissions();
            builder.SeedLocations();

            #endregion

        }
    }
}
