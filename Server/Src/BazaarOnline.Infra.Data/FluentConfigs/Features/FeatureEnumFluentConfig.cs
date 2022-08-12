using BazaarOnline.Domain.Entities.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BazaarOnline.Infra.Data.FluentConfigs;

public class FeatureEnumFluentConfig : IEntityTypeConfiguration<FeatureEnum>
{
    public void Configure(EntityTypeBuilder<FeatureEnum> builder)
    {
        builder.HasKey(fe => fe.Id);

        ConfigureProperties(builder);
        ConfigureRelations(builder);
        ConfigureIndexes(builder);
        ConfigureQueryFilters(builder);
    }


    private void ConfigureProperties(EntityTypeBuilder<FeatureEnum> builder)
    {
        builder.Property(fe => fe.Name)
            .IsRequired()
            .HasMaxLength(64);
    }

    private void ConfigureRelations(EntityTypeBuilder<FeatureEnum> builder)
    {
        builder.HasMany(fe => fe.FeatureEnumValues)
            .WithOne(fev => fev.FeatureEnum)
            .HasForeignKey(fev => fev.FeatureEnumId);

        builder.HasMany(fe => fe.Features)
            .WithOne(f => f.FeatureEnum)
            .HasForeignKey(f => f.FeatureEnumId);
    }

    private void ConfigureIndexes(EntityTypeBuilder<FeatureEnum> builder)
    {

    }

    private void ConfigureQueryFilters(EntityTypeBuilder<FeatureEnum> builder)
    {

    }
}
