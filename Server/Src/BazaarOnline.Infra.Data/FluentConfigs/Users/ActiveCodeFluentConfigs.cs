using BazaarOnline.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BazaarOnline.Infra.Data.FluentConfigs
{
    public class ActiveCodeFluentConfigs : IEntityTypeConfiguration<ActiveCode>
    {
        public void Configure(EntityTypeBuilder<ActiveCode> builder)
        {
            builder.HasKey(m => m.Id);

            ConfigureProperties(builder);
            ConfigureRelations(builder);
            ConfigureIndexes(builder);
            ConfigureQueryFilters(builder);
        }


        private void ConfigureProperties(EntityTypeBuilder<ActiveCode> builder)
        {
            builder.Property(m => m.Code)
                .IsRequired()
                .HasMaxLength(64);

            builder.Property(m => m.ExpireDate)
                .IsRequired();
        }

        private void ConfigureRelations(EntityTypeBuilder<ActiveCode> builder)
        {
            builder.HasOne(a => a.User)
                .WithMany(u => u.ActiveCodes)
                .HasForeignKey(u => u.UserId);
        }

        private void ConfigureIndexes(EntityTypeBuilder<ActiveCode> builder)
        {

        }
        private void ConfigureQueryFilters(EntityTypeBuilder<ActiveCode> builder)
        {
            builder.HasQueryFilter(m => m.ExpireDate > DateTime.Now);
        }
    }
}
