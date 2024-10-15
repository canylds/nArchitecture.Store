using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Categories").HasKey(c => c.Id);

        builder.Property(c => c.Id).HasColumnName("Id").IsRequired();
        builder.Property(c => c.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(c => c.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(c => c.DeletedDate).HasColumnName("DeletedDate");
        builder.Property(c => c.Name).HasColumnName("Name").IsRequired();
        builder.Property(c => c.Description).HasColumnName("Description").IsRequired();
        builder.Property(c => c.ImageUrl).HasColumnName("ImageUrl");

        builder.HasMany(c => c.Products).WithOne(p => p.Category).HasForeignKey(p => p.CategoryId);

        builder.HasIndex(indexExpression: c => c.Name, name: "UK_Categories_Name").IsUnique();

        builder.HasQueryFilter(c => !c.DeletedDate.HasValue);

        builder.HasData(_seeds);
    }

    private IEnumerable<Category> _seeds
    {
        get
        {
            yield return new()
            {
                Id = 1,
                CreatedDate = DateTime.UtcNow,
                Name = "Giyim",
                Description = "Bu kategori giysiler içerir.",
                ImageUrl = "https://cdn.myikas.com/images/6d452771-fa42-482d-a9a5-b47e65a5bf47/f7875799-b576-4294-930a-198ec803046e/1080/t-shirt-black-a.jpg"
            };
        }
    }
}