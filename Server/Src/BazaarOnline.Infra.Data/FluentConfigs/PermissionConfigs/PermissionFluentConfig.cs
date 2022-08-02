using BazaarOnline.Domain.Entities.Permissions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BazaarOnline.Infra.Data.FluentConfigs
{
    public class PermissionFluentConfig : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.HasKey(p => p.Id);

            ConfigureProperties(builder);
            ConfigureRelations(builder);
        }

        private void ConfigureProperties(EntityTypeBuilder<Permission> builder)
        {
            builder.Property(p => p.Title)
                .IsRequired()
                .HasMaxLength(64);
        }

        private void ConfigureRelations(EntityTypeBuilder<Permission> builder)
        {
            builder.HasOne(p => p.PermissionGroup)
                .WithMany(pg => pg.Permissions)
                .HasForeignKey(p => p.PermissionGroupId);

            builder.HasMany(p => p.RolePermissions)
                .WithOne(rp => rp.Permission)
                .HasForeignKey(rp => rp.PermissionId);
        }
    }
}
