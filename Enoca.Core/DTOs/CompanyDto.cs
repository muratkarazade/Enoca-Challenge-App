using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.Core.DTOs
{
    public class CompanyDto : BaseDto
    {
        public string Name { get; set; }
        public bool IsStatus { get; set; }
        public TimeSpan OrderStartTime { get; set; }
        public TimeSpan OrderFinishTime { get; set; }
    }
}
