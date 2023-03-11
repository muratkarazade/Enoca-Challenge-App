using Enoca.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.Repository.Seeds
{
    public class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                 new Product {Id=1, CompanyId = 1, Name = "Product A1", Stock = 10, Price = 50 },
                 new Product { Id = 2, CompanyId = 1, Name = "Product A2", Stock = 5, Price = 75 },
                 new Product { Id = 3, CompanyId = 2, Name = "Product B1", Stock = 20, Price = 30 },
                 new Product { Id = 4, CompanyId = 2, Name = "Product B2", Stock = 15, Price = 40 },
                 new Product { Id = 5, CompanyId = 3, Name = "Product C1", Stock = 8, Price = 90 },
                 new Product { Id = 6, CompanyId = 3, Name = "Product C2", Stock = 12, Price = 80 }
                );
        }
    }
}
