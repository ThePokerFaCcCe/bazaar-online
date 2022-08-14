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
            .WithOne(fe => fe.Feature)
            .HasForeignKey<FeatureEnum>(fe => fe.FeatureId);

        builder.HasOne(f => f.FeatureInteger)
            .WithOne(fi => fi.Feature)
            .HasForeignKey<FeatureInteger>(fi => fi.FeatureId);

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
