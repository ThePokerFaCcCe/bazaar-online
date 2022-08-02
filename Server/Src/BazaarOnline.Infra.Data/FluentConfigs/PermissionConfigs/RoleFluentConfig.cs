using BazaarOnline.Domain.Entities.Permissions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BazaarOnline.Infra.Data.FluentConfigs
{
    public class RoleFluentConfig : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(r => r.Id);
            ConfigureProperties(builder);
            ConfigureRelations(builder);
        }

        private void ConfigureProperties(EntityTypeBuilder<Role> builder)
        {
            builder.Property(r => r.Title)
                .IsRequired()
                .HasMaxLength(64);
        }

        private void ConfigureRelations(EntityTypeBuilder<Role> builder)
        {
            builder.HasMany(r => r.RolePermissions)
                .WithOne(rp => rp.Role)
                .HasForeignKey(rp => rp.RoleId);

            builder.HasMany(r => r.UserRoles)
                .WithOne(ur => ur.Role)
                .HasForeignKey(ur => ur.RoleId);
        }

    }
}
