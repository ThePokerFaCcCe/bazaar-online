using BazaarOnline.Domain.Entities.Advertiesements;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BazaarOnline.Infra.Data.FluentConfigs;

public class AdvertiesementFluentConfig : IEntityTypeConfiguration<Advertiesement>
{
    public void Configure(EntityTypeBuilder<Advertiesement> builder)
    {
        builder.HasKey(a => a.Id);

        ConfigureProperties(builder);
        ConfigureRelations(builder);
        ConfigureIndexes(builder);
        ConfigureQueryFilters(builder);
    }


    private void ConfigureProperties(EntityTypeBuilder<Advertiesement> builder)
    {
        builder.Property(a => a.Title)
            .IsRequired()
            .HasMaxLength(64);

        builder.Property(a => a.Description)
            .IsRequired()
            .HasMaxLength(1000);

        builder.Property(a => a.DeniedByAdminReason)
            .HasMaxLength(1000);

        builder.Property(a => a.DeletedByAdminReason)
            .HasMaxLength(1000);

        builder.Property(a => a.Address)
            .HasMaxLength(100);

        builder.Property(a => a.Latitude)
            .IsRequired();

        builder.Property(a => a.Longitude)
            .IsRequired();

        builder.Property(a => a.IsAccepted)
            .IsRequired()
            .HasDefaultValue(false);

        builder.Property(a => a.IsDeleted)
            .IsRequired()
            .HasDefaultValue(false);

        builder.Property(a => a.IsDeniedByAdmin)
            .IsRequired()
            .HasDefaultValue(false);

        builder.Property(a => a.IsDeletedByAdmin)
            .IsRequired()
            .HasDefaultValue(false);

        builder.Property(a => a.IsChatOnly)
            .IsRequired()
            .HasDefaultValue(false);

        builder.Property(a => a.CreateDate)
            .IsRequired()
            .HasDefaultValueSql("getdate()");
    }

    private void ConfigureRelations(EntityTypeBuilder<Advertiesement> builder)
    {
        builder.HasOne(a => a.User)
            .WithMany(u => u.Advertiesements)
            .HasForeignKey(a => a.UserId);

        builder.HasOne(a => a.City)
            .WithMany(c => c.Advertiesements)
            .HasForeignKey(a => a.CityId);

        builder.HasOne(a => a.Category)
            .WithMany(c => c.Advertiesements)
            .HasForeignKey(a => a.CategoryId);

        builder.HasMany(a => a.AdvertiesementFeatureValues)
            .WithOne(af => af.Advertiesement)
            .HasForeignKey(af => af.AdvertiesementId);

        builder.HasMany(a => a.AdvertiesementPictures)
            .WithOne(ap => ap.Advertiesement)
            .HasForeignKey(ap => ap.AdvertiesementId);

        builder.HasOne(a => a.AdvertiesementPrice)
            .WithOne(ap => ap.Advertiesement)
            .HasForeignKey<AdvertiesementPrice>(ap => ap.AdvertiesementId);
    }

    private void ConfigureIndexes(EntityTypeBuilder<Advertiesement> builder)
    {

    }

    private void ConfigureQueryFilters(EntityTypeBuilder<Advertiesement> builder)
    {
        builder.HasQueryFilter(a => !a.IsDeleted && a.IsAccepted);
    }
}
