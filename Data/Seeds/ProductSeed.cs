using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Seeds
{
    public class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product { Id = 1, Name = "Pilot Kalem", Price = 12.50m, Stock = 100, CategoryId = 1 },
                new Product { Id = 2, Name = "Kurşun Kalem", Price = 40.50m, Stock = 200, CategoryId = 1 },
                new Product { Id = 3, Name = "Tükenmez Kalem", Price = 500m, Stock = 300, CategoryId = 1 },
                new Product { Id = 4, Name = "Küçük Boy Defter", Price = 120m, Stock = 300, CategoryId = 2 },
                new Product { Id = 5, Name = "Orta Boy Defter", Price = 120m, Stock = 300, CategoryId = 2 },
                new Product { Id = 6, Name = "Büyük Boy Defter", Price = 120m, Stock = 300, CategoryId = 2 }
                );
        }
    }
}
