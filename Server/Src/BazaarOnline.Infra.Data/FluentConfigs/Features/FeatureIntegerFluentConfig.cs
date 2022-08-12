using BazaarOnline.Domain.Entities.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BazaarOnline.Infra.Data.FluentConfigs.Features;

public class FeatureIntegerFluentConfig : IEntityTypeConfiguration<FeatureInteger>
{
    public void Configure(EntityTypeBuilder<FeatureInteger> builder)
    {
        builder.HasKey(fe => fe.Id);

        ConfigureProperties(builder);
        ConfigureRelations(builder);
        ConfigureIndexes(builder);
        ConfigureQueryFilters(builder);
    }


    private void ConfigureProperties(EntityTypeBuilder<FeatureInteger> builder)
    {
        builder.Property(fe => fe.Name)
            .IsRequired()
            .HasMaxLength(64);

        builder.Property(fe => fe.MinimumValue)
            .IsRequired();

        builder.Property(fe => fe.MaximumValue)
            .IsRequired();
    }

    private void ConfigureRelations(EntityTypeBuilder<FeatureInteger> builder)
    {
        builder.HasMany(fe => fe.Features)
            .WithOne(f => f.FeatureInteger)
            .HasForeignKey(f => f.FeatureIntegerId);
    }

    private void ConfigureIndexes(EntityTypeBuilder<FeatureInteger> builder)
    {

    }

    private void ConfigureQueryFilters(EntityTypeBuilder<FeatureInteger> builder)
    {

    }
}
