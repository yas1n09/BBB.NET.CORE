using BBB.NET.CORE.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBB.NET.CORE.Responses.Reporting
{
    public class GetMeetingStatsResponse : BaseResponse
    {
        public string meetingID { get; set; }
        public int participantCount { get; set; }
        public int activeUsers { get; set; }
        public long duration { get; set; }
        public string message { get; set; }
    }
}
