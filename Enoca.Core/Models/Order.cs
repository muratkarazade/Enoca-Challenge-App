using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.Core.Models
{
    public class Order : BaseEntity
    {
        public string OrdererName { get; set; }
        public int ProductId { get; set; }       
        public  Product Product { get; set; }


    }
}
