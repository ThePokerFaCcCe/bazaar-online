using BazaarOnline.Domain.Entities.Permissions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BazaarOnline.Infra.Data.FluentConfigs
{
    public class PermissionGroupFluentConfig : IEntityTypeConfiguration<PermissionGroup>
    {
        public void Configure(EntityTypeBuilder<PermissionGroup> builder)
        {
            builder.HasKey(pg => pg.Id);

            ConfigureProperties(builder);
            ConfigureRelations(builder);
        }

        private void ConfigureProperties(EntityTypeBuilder<PermissionGroup> builder)
        {
            builder.Property(pg => pg.Title)
                .IsRequired()
                .HasMaxLength(64);
        }

        private void ConfigureRelations(EntityTypeBuilder<PermissionGroup> builder)
        {
            builder.HasMany(pg => pg.Permissions)
                .WithOne(p => p.PermissionGroup)
                .HasForeignKey(p => p.PermissionGroupId);
        }

    }
}
