using BazaarOnline.Domain.Entities.Permissions;
using BazaarOnline.Infra.Data.Seeds.DefaultDatas;
using Microsoft.EntityFrameworkCore;

namespace BazaarOnline.Infra.Data.Seeds
{
    /// <summary>
    /// Extention class for Seeding database
    /// </summary>
    public static class SeedExtention
    {
        /// <summary>
        /// Database Permission And Role Seeds
        /// </summary>
        public static void SeedPermissions(this ModelBuilder builder)
        {
            builder.Entity<PermissionGroup>().HasData(DefaultPermissionGroups.Groups);

            builder.Entity<Permission>().HasData(DefaultPermissions.Permissions);

            builder.Entity<Role>().HasData(DefaultRoles.Roles);

            builder.Entity<RolePermission>().HasData(DefaultRolePermissions.RolePermissions);
        }
    }
}
