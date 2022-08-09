using BazaarOnline.Domain.Entities.Categories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BazaarOnline.Infra.Data.FluentConfigs;

public class CategoryFluentConfig : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(c => c.Id);

        ConfigureProperties(builder);
        ConfigureRelations(builder);
        ConfigureIndexes(builder);
        ConfigureQueryFilters(builder);
    }


    private void ConfigureProperties(EntityTypeBuilder<Category> builder)
    {
        builder.Property(c => c.Title)
            .IsRequired()
            .HasMaxLength(64);

        builder.Property(c => c.Icon)
            .HasMaxLength(64);
    }

    private void ConfigureRelations(EntityTypeBuilder<Category> builder)
    {
        builder.HasOne(c => c.ParentCategory)
            .WithMany(c => c.ChildCategories)
            .HasForeignKey(c => c.ParentId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(c => c.ChildCategories)
            .WithOne(c => c.ParentCategory)
            .HasForeignKey(c => c.ParentId)
            .OnDelete(DeleteBehavior.Restrict);
    }

    private void ConfigureIndexes(EntityTypeBuilder<Category> builder)
    {

    }

    private void ConfigureQueryFilters(EntityTypeBuilder<Category> builder)
    {

    }
}
