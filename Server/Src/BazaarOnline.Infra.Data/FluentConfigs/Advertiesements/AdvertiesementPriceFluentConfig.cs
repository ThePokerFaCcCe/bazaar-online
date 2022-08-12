using BazaarOnline.Domain.Entities.Advertiesements;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Namespace;

public class AdvertiesementPriceFluentConfig : IEntityTypeConfiguration<AdvertiesementPrice>
{
    public void Configure(EntityTypeBuilder<AdvertiesementPrice> builder)
    {
        builder.HasKey(ap => ap.AdvertiesementId);

        ConfigureProperties(builder);
        ConfigureRelations(builder);
        ConfigureIndexes(builder);
        ConfigureQueryFilters(builder);
    }


    private void ConfigureProperties(EntityTypeBuilder<AdvertiesementPrice> builder)
    {
        builder.Property(ap => ap.Type)
            .IsRequired()
            .HasConversion<string>();

        builder.Property(ap => ap.IsAgreement)
            .IsRequired();
    }

    private void ConfigureRelations(EntityTypeBuilder<AdvertiesementPrice> builder)
    {
        builder.HasOne(ap => ap.Advertiesement)
            .WithOne(a => a.AdvertiesementPrice)
            .HasForeignKey<AdvertiesementPrice>(ap => ap.AdvertiesementId);
    }

    private void ConfigureIndexes(EntityTypeBuilder<AdvertiesementPrice> builder)
    {

    }

    private void ConfigureQueryFilters(EntityTypeBuilder<AdvertiesementPrice> builder)
    {

    }
}
