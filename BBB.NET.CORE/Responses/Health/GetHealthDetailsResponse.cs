using BBB.NET.CORE.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBB.NET.CORE.Responses.Health
{
    public class GetHealthDetailsResponse : BaseResponse
    {
        public bool healthy { get; set; }
        public int activeMeetings { get; set; }
        public long uptime { get; set; }
        public string cpuUsage { get; set; }
        public string memoryUsage { get; set; }
        public string message { get; set; }
    }
}
