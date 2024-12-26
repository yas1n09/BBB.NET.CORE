using BBB.NET.CORE.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBB.NET.CORE.Responses.Reporting
{
    public class GetServerStatsResponse : BaseResponse
    {
        public int totalMeetings { get; set; }
        public int activeUsers { get; set; }
        public long serverUptime { get; set; }
        public string message { get; set; }
    }
}
