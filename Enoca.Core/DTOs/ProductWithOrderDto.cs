﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.Core.DTOs
{
    public class ProductWithOrderDto : BaseDto
    {
        public List<OrderDto> Orders { get; set; }
    }
}
