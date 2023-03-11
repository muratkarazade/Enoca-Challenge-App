using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.Core.Models
{
    public class Product : BaseEntity
    {
        public string? Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public virtual Company Company { get; set; }
        public int CompanyId { get; set; }
        public ICollection<Order> Orders { get; set; }

    }
}
