using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Enoca.Core.DTOs
{
    public class OrderTimeUpdateDto
    {
        public string OrderStartTimeString { get; set; }
        public string OrderFinishTimeString { get; set; }

        [JsonIgnore]
        public TimeSpan OrderStartTime
        {
            get
            {
                return TimeSpan.Parse(OrderStartTimeString);
            }
            set
            {
                OrderStartTimeString = value.ToString();
            }
        }

        [JsonIgnore]
        public TimeSpan OrderFinishTime
        {
            get
            {
                return TimeSpan.Parse(OrderFinishTimeString);
            }
            set
            {
                OrderFinishTimeString = value.ToString();
            }
        }
    }
}
