using BazaarOnline.Domain.Entities.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BazaarOnline.Infra.Data.FluentConfigs;

public class FeatureFluentConfig : IEntityTypeConfiguration<Feature>
{
    public void Configure(EntityTypeBuilder<Feature> builder)
    {
        builder.HasKey(f => f.Id);

        ConfigureProperties(builder);
        ConfigureRelations(builder);
        ConfigureIndexes(builder);
        ConfigureQueryFilters(builder);
    }


    private void ConfigureProperties(EntityTypeBuilder<Feature> builder)
    {
        builder.Property(f => f.Title)
            .IsRequired()
            .HasMaxLength(64);

        builder.Property(f => f.IsRequired)
            .IsRequired();

        builder.Property(f => f.FeatureType)
            .IsRequired()
            .HasConversion<string>();
    }

    private void ConfigureRelations(EntityTypeBuilder<Feature> builder)
    {
        builder.HasOne(f => f.FeatureEnum)
            .WithMany(fe => fe.Features)
            .HasForeignKey(f => f.FeatureEnumId);

        builder.HasOne(f => f.FeatureInteger)
            .WithMany(fi => fi.Features)
            .HasForeignKey(f => f.FeatureIntegerId);

        builder.HasMany(f => f.AdvertiesementFeatureValues)
            .WithOne(af => af.Feature)
            .HasForeignKey(af => af.FeatureId);

        builder.HasMany(f => f.CategoryFeatures)
            .WithOne(cf => cf.Feature)
            .HasForeignKey(cf => cf.FeatureId);
    }

    private void ConfigureIndexes(EntityTypeBuilder<Feature> builder)
    {

    }

    private void ConfigureQueryFilters(EntityTypeBuilder<Feature> builder)
    {

    }
}
