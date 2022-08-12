using BazaarOnline.Domain.Entities.Advertiesements;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BazaarOnline.Infra.Data.FluentConfigs;

public class AdvertiesementFeatureValueFluentConfig : IEntityTypeConfiguration<AdvertiesementFeatureValue>
{
    public void Configure(EntityTypeBuilder<AdvertiesementFeatureValue> builder)
    {
        builder.HasKey(af => new { af.FeatureId, af.AdvertiesementId });

        ConfigureProperties(builder);
        ConfigureRelations(builder);
        ConfigureIndexes(builder);
        ConfigureQueryFilters(builder);
    }


    private void ConfigureProperties(EntityTypeBuilder<AdvertiesementFeatureValue> builder)
    {
        builder.Property(f => f.Value)
            .HasMaxLength(100);
    }

    private void ConfigureRelations(EntityTypeBuilder<AdvertiesementFeatureValue> builder)
    {
        builder.HasOne(af => af.Feature)
            .WithMany(f => f.AdvertiesementFeatureValues)
            .HasForeignKey(af => af.FeatureId);

        builder.HasOne(af => af.Advertiesement)
            .WithMany(a => a.AdvertiesementFeatureValues)
            .HasForeignKey(af => af.AdvertiesementId);
    }

    private void ConfigureIndexes(EntityTypeBuilder<AdvertiesementFeatureValue> builder)
    {

    }

    private void ConfigureQueryFilters(EntityTypeBuilder<AdvertiesementFeatureValue> builder)
    {

    }
}
