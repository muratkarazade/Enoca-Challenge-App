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
    public class CompanySeed : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {

            builder.HasData(
                new Company {Id=1, Name = "Company A", IsStatus = true, OrderStartTime = new TimeSpan(9, 0, 0), OrderFinishTime = new TimeSpan(17, 0, 0) },
                new Company {Id=2, Name = "Company B", IsStatus = true, OrderStartTime = new TimeSpan(10, 0, 0), OrderFinishTime = new TimeSpan(16, 0, 0) },
                new Company {Id=3, Name = "Company C", IsStatus = false, OrderStartTime = new TimeSpan(8, 0, 0), OrderFinishTime = new TimeSpan(18, 0, 0) }
                );
        }
    }
}
