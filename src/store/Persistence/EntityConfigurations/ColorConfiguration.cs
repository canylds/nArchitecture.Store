using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ColorConfiguration : IEntityTypeConfiguration<Color>
{
    public void Configure(EntityTypeBuilder<Color> builder)
    {
        builder.ToTable("Colors").HasKey(c => c.Id);

        builder.Property(c => c.Id).HasColumnName("Id").IsRequired();
        builder.Property(c => c.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(c => c.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(c => c.DeletedDate).HasColumnName("DeletedDate");
        builder.Property(c => c.Name).HasColumnName("Name");

        builder.HasMany(c => c.ProductVariants).WithOne(pv => pv.Color).HasForeignKey(pv => pv.ColorId);

        builder.HasIndex(indexExpression: c => c.Name, name: "UK_Colors_Name").IsUnique();

        builder.HasQueryFilter(c => !c.DeletedDate.HasValue);

        builder.HasData(_seeds);
    }

    private IEnumerable<Color> _seeds
    {
        get
        {
            int id = 0;

            yield return new Color(id: ++id, name: "Kırmızı");

            yield return new Color(id: ++id, name: "Mavi");
        }
    }
}
