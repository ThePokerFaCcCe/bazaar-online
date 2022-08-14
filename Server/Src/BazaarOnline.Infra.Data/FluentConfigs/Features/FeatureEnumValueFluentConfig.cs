using BazaarOnline.Domain.Entities.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BazaarOnline.Infra.Data.FluentConfigs;

public class FeatureEnumValueFluentConfig : IEntityTypeConfiguration<FeatureEnumValue>
{
    public void Configure(EntityTypeBuilder<FeatureEnumValue> builder)
    {
        builder.HasKey(fev => fev.Id);

        ConfigureProperties(builder);
        ConfigureRelations(builder);
        ConfigureIndexes(builder);
        ConfigureQueryFilters(builder);
    }


    private void ConfigureProperties(EntityTypeBuilder<FeatureEnumValue> builder)
    {
        builder.Property(fev => fev.Value)
            .IsRequired()
            .HasMaxLength(64);
    }

    private void ConfigureRelations(EntityTypeBuilder<FeatureEnumValue> builder)
    {
        builder.HasOne(fev => fev.FeatureEnum)
            .WithMany(fe => fe.FeatureEnumValues)
            .HasForeignKey(fev => fev.FeatureEnumId);
    }

    private void ConfigureIndexes(EntityTypeBuilder<FeatureEnumValue> builder)
    {
        builder.HasIndex(fev => fev.Value);
    }

    private void ConfigureQueryFilters(EntityTypeBuilder<FeatureEnumValue> builder)
    {

    }
}
