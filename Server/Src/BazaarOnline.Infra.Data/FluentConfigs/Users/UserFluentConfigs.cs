using BazaarOnline.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BazaarOnline.Infra.Data.FluentConfigs
{
    public class UserFluentConfigs : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Ignore(u => u.FullName);


            ConfigureProperties(builder);
            ConfigureRelations(builder);
            ConfigureIndexes(builder);
            ConfigureQueryFilters(builder);
        }


        private void ConfigureProperties(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.Email)
                .HasMaxLength(100);

            builder.Property(u => u.PhoneNumber)
                .IsRequired()
                .HasMaxLength(11);

            builder.Property(u => u.Password)
                .IsRequired();

            builder.Property(u => u.FirstName)
                .IsRequired()
                .HasMaxLength(32);

            builder.Property(u => u.LastName)
                .IsRequired()
                .HasMaxLength(32);

            builder.Property(u => u.CreateDate)
                .IsRequired()
                .HasDefaultValueSql("getdate()");

            builder.Property(u => u.IsActive)
                .IsRequired()
                .HasDefaultValue<bool>(false);

            builder.Property(u => u.IsEmailActive)
                .IsRequired()
                .HasDefaultValue<bool>(false);

            builder.Property(u => u.IsDeleted)
                .IsRequired()
                .HasDefaultValue<bool>(false);
        }
        private void ConfigureQueryFilters(EntityTypeBuilder<User> builder)
        {
            builder.HasQueryFilter(u => u.IsDeleted == false);
        }

        private void ConfigureRelations(EntityTypeBuilder<User> builder)
        {
            builder.HasMany(u => u.UserRoles)
                .WithOne(ur => ur.User)
                .HasForeignKey(ur => ur.UserId);

            builder.HasMany(c => c.Advertiesements)
                .WithOne(a => a.User)
                .HasForeignKey(a => a.UserId);

            builder.HasMany(u => u.ActiveCodes)
                .WithOne(a => a.User)
                .HasForeignKey(a => a.UserId);


        }

        private void ConfigureIndexes(EntityTypeBuilder<User> builder)
        {
            builder.HasIndex(u => u.Email)
                .IsUnique();
        }
    }
}
