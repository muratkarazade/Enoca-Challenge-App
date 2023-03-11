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
    public class OrderSeed : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasData(
                new Order { Id = 1, ProductId = 1, OrdererName = "Ali", CreatedDate = new DateTime(2023, 3, 10) },
                new Order { Id = 2,  ProductId = 3, OrdererName = "Veli", CreatedDate = new DateTime(2023, 3, 10) },
                new Order { Id = 3,  ProductId = 5, OrdererName = "Ahmet", CreatedDate = new DateTime(2023, 3, 9) },
                new Order { Id = 4,  ProductId = 6, OrdererName = "Mehmet", CreatedDate = new DateTime(2023, 3, 8) }

                );
        }
    }
}
