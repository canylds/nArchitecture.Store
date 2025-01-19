using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
{
    public void Configure(EntityTypeBuilder<RefreshToken> builder)
    {
        builder.ToTable("RefreshTokens").HasKey(rt => rt.Id);

        builder.Property(rt => rt.Id).HasColumnName("Id").IsRequired();
        builder.Property(rt => rt.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(rt => rt.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(rt => rt.DeletedDate).HasColumnName("DeletedDate");
        builder.Property(rt => rt.UserId).HasColumnName("UserId").IsRequired();
        builder.Property(rt => rt.Token).HasColumnName("Token").IsRequired();
        builder.Property(rt => rt.ExpirationDate).HasColumnName("Expires").IsRequired();
        builder.Property(rt => rt.CreatedByIp).HasColumnName("CreatedByIp").IsRequired();
        builder.Property(rt => rt.RevokedDate).HasColumnName("Revoked");
        builder.Property(rt => rt.RevokedByIp).HasColumnName("RevokedByIp");
        builder.Property(rt => rt.ReplacedByToken).HasColumnName("ReplacedByToken");
        builder.Property(rt => rt.ReasonRevoked).HasColumnName("ReasonRevoked");

        builder.HasOne(rt => rt.User).WithMany(u => u.RefreshTokens).HasForeignKey(rt => rt.UserId);

        builder.HasQueryFilter(rt => !rt.DeletedDate.HasValue);
    }
}
