using BBB.NET.CORE.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBB.NET.CORE.Responses.Meeting
{
    public class GetMeetingInfoResponse : BaseResponse
    {
        public string meetingID { get; set; }
        public string meetingName { get; set; }
        public int participantCount { get; set; }
        public bool running { get; set; }
        public long startTime { get; set; }
        public long endTime { get; set; }
    }
}
