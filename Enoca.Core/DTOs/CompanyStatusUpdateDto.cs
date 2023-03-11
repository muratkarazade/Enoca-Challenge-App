using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.Core.DTOs
{
    public class CompanyStatusUpdateDto : BaseDto
    {
        public TimeSpan OrderStartTime { get; set; }
    }
}
