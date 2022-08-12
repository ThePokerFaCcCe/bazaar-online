using BazaarOnline.Domain.Entities.Advertiesements;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BazaarOnline.Infra.Data.FluentConfigs.Advertiesements;

public class AdvertiesementPictureFluentConfig : IEntityTypeConfiguration<AdvertiesementPicture>
{
    public void Configure(EntityTypeBuilder<AdvertiesementPicture> builder)
    {
        builder.HasKey(ap => ap.Id);

        ConfigureProperties(builder);
        ConfigureRelations(builder);
        ConfigureIndexes(builder);
        ConfigureQueryFilters(builder);
    }


    private void ConfigureProperties(EntityTypeBuilder<AdvertiesementPicture> builder)
    {
        builder.Property(ap => ap.PictureName)
            .IsRequired()
            .HasMaxLength(200);
    }

    private void ConfigureRelations(EntityTypeBuilder<AdvertiesementPicture> builder)
    {
        builder.HasOne(ap => ap.Advertiesement)
            .WithMany(a => a.AdvertiesementPictures)
            .HasForeignKey(ap => ap.AdvertiesementId);
    }

    private void ConfigureIndexes(EntityTypeBuilder<AdvertiesementPicture> builder)
    {

    }

    private void ConfigureQueryFilters(EntityTypeBuilder<AdvertiesementPicture> builder)
    {

    }
}
