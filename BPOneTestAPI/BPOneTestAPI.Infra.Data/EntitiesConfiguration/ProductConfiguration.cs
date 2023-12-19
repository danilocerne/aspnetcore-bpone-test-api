using BPOneTestAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BPOneTestAPI.Infra.Data.EntitiesConfiguration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Description).HasMaxLength(200).IsRequired();
            builder.Property(p => p.Price).HasPrecision(10, 2);
            builder.HasOne(e => e.ProductCategory).WithMany(e => e.Products)
                .HasForeignKey(e => e.ProductCategoryId);
        }
    }
}