using BazaarOnline.Domain.Entities.Locations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BazaarOnline.Infra.Data.FluentConfigs;

public class CityFluentConfig : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        builder.HasKey(c => c.Id);

        ConfigureProperties(builder);
        ConfigureRelations(builder);
        ConfigureIndexes(builder);
        ConfigureQueryFilters(builder);
    }


    private void ConfigureProperties(EntityTypeBuilder<City> builder)
    {
        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(c => c.ISO3166)
            .IsRequired()
            .HasMaxLength(5);
    }

    private void ConfigureRelations(EntityTypeBuilder<City> builder)
    {
        builder.HasMany(c => c.Advertiesements)
            .WithOne(a => a.City)
            .HasForeignKey(a => a.CityId);
    }

    private void ConfigureIndexes(EntityTypeBuilder<City> builder)
    {
        builder.HasIndex(c => c.ISO3166)
            .IsUnique();
    }

    private void ConfigureQueryFilters(EntityTypeBuilder<City> builder)
    {

    }
}
