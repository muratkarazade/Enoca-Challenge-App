﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.Core.Models
{
    public class Company : BaseEntity
    {
        public string Name { get; set; }
        public bool IsStatus { get; set; }
        public TimeSpan OrderStartTime { get; set; } = TimeSpan.FromHours(1);
        public TimeSpan OrderFinishTime { get; set; } = TimeSpan.FromHours(1);
        public ICollection<Product> Products { get; set; }
        
    }
}
