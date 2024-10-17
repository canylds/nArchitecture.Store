using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ProductImageConfiguration : IEntityTypeConfiguration<ProductImage>
{
    public void Configure(EntityTypeBuilder<ProductImage> builder)
    {
        builder.ToTable("ProductImages").HasKey(pi => pi.Id);

        builder.Property(pi => pi.Id).HasColumnName("Id").IsRequired();
        builder.Property(pi => pi.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(pi => pi.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(pi => pi.DeletedDate).HasColumnName("DeletedDate");
        builder.Property(pi => pi.ProductId).HasColumnName("ProductId").IsRequired();
        builder.Property(pi => pi.Url).HasColumnName("Url").IsRequired();

        builder.HasOne(pi => pi.Product).WithMany(p => p.ProductImages).HasForeignKey(pi => pi.ProductId);

        builder.HasQueryFilter(pi => !pi.DeletedDate.HasValue);

        builder.HasData(_seeds);
    }

    private IEnumerable<ProductImage> _seeds
    {
        get
        {
            int id = 0;

            yield return new ProductImage
            {
                Id = ++id,
                ProductId = 1,
                Url = "https://i.pinimg.com/originals/99/86/ab/9986ab7d3cee03f5949c9587938bb5c4.jpg"
            };

            yield return new ProductImage
            {
                Id = ++id,
                ProductId = 1,
                Url = "https://t4.ftcdn.net/jpg/07/46/18/01/360_F_746180145_5A7i83iHIGbKBXb2ArfZeN0BDLwOiW4g.jpg"
            };

            yield return new ProductImage
            {
                Id = ++id,
                ProductId = 2,
                Url = "https://004406.cdn.akinoncloud.com/products/2020/06/11/96244/61c41c8f-a14d-4575-8ccb-52855c7994b5_size350x525_quality90_cropCenter.jpg"
            };

            yield return new ProductImage
            {
                Id = ++id,
                ProductId = 2,
                Url = "https://004406.a-cdn.akinoncloud.com/products/2024/02/29/595907/2230e9c3-4c05-4812-86a9-0fb428cc6ef1_size555x830_quality90_cropCenter.jpg"
            };

            yield return new ProductImage
            {
                Id = ++id,
                ProductId = 2,
                Url = "https://static.ticimax.cloud/cdn-cgi/image/width=-,quality=85/56971/uploads/urunresimleri/buyuk/koyu-mavi-uzun-kollu-ekoseli-cepli-gar--529e-.jpg"
            };
        }
    }
}
