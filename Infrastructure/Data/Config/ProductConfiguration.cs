using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Description).IsRequired();
            builder.Property(x => x.Price).HasColumnType("decimal(18,2)");
            builder.Property(x => x.ImageUrl).IsRequired();
            builder.HasOne(x => x.ProductBrand).WithMany()
                .HasForeignKey(x => x.ProductBrandId);
            builder.HasOne(x => x.ProductType).WithMany()
                .HasForeignKey(x => x.ProductTypeId);
        }
    }
}
