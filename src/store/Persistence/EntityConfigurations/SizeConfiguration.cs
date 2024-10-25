using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class SizeConfiguration : IEntityTypeConfiguration<Size>
{
    public void Configure(EntityTypeBuilder<Size> builder)
    {
        builder.ToTable("Sizes").HasKey(s => s.Id);

        builder.Property(s => s.Id).HasColumnName("Id").IsRequired();
        builder.Property(s => s.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(s => s.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(s => s.DeletedDate).HasColumnName("DeletedDate");
        builder.Property(s => s.Name).HasColumnName("Name");

        builder.HasMany(s => s.ProductVariants).WithOne(pv => pv.Size).HasForeignKey(pv => pv.SizeId);

        builder.HasIndex(indexExpression: s => s.Name, name: "UK_Sizes_Name").IsUnique();

        builder.HasQueryFilter(s => !s.DeletedDate.HasValue);

        builder.HasData(_seeds);
    }

    private IEnumerable<Size> _seeds
    {
        get
        {
            int id = 0;

            yield return new Size(id: ++id, name: "S");

            yield return new Size(id: ++id, name: "M");

            yield return new Size(id: ++id, name: "L");
        }
    }
}
