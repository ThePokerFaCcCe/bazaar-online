using BazaarOnline.Domain.Entities.Categories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Namespace;

public class CategoryFeatureFluentConfig : IEntityTypeConfiguration<CategoryFeature>
{
    public void Configure(EntityTypeBuilder<CategoryFeature> builder)
    {
        builder.HasKey(cf => new { cf.FeatureId, cf.CategoryId });

        ConfigureProperties(builder);
        ConfigureRelations(builder);
        ConfigureIndexes(builder);
        ConfigureQueryFilters(builder);
    }


    private void ConfigureProperties(EntityTypeBuilder<CategoryFeature> builder)
    {

    }

    private void ConfigureRelations(EntityTypeBuilder<CategoryFeature> builder)
    {
        builder.HasOne(cf => cf.Category)
            .WithMany(c => c.CategoryFeatures)
            .HasForeignKey(c => c.CategoryId);

        builder.HasOne(cf => cf.Feature)
            .WithMany(f => f.CategoryFeatures)
            .HasForeignKey(cf => cf.FeatureId);
    }

    private void ConfigureIndexes(EntityTypeBuilder<CategoryFeature> builder)
    {

    }

    private void ConfigureQueryFilters(EntityTypeBuilder<CategoryFeature> builder)
    {

    }
}
