using Enoca.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Enoca.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.Repository.Configurations
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn(1,1);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(150);
            builder.Property(x => x.IsStatus).IsRequired();

            builder.Property(x => x.OrderStartTime).IsRequired();

            builder.Property(f => f.OrderFinishTime).IsRequired();
            builder.ToTable("Companies");

            builder.HasMany(c => c.Products)
             .WithOne(p => p.Company)
             .HasForeignKey(p => p.CompanyId);


        }
    }
}
