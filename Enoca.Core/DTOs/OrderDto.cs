using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.Core.DTOs
{
    public class OrderDto : BaseDto
    {
        public string OrdererName { get; set; }
        public int ProductId { get; set; }
    }
}
