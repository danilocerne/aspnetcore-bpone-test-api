using BPOneTestAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BPOneTestAPI.Infra.Data.EntitiesConfiguration
{
    public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(p => p.Name).HasMaxLength(100).IsRequired();

            builder.HasData(
                new ProductCategory(1, "Ferro", 1),
                new ProductCategory(2, "Plástico", 1),
                new ProductCategory(3, "Papel", 1)
            );
        }
    }
}