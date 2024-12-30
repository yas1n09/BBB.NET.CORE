using BBB.NET.CORE.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBB.NET.CORE.Responses.Meeting
{
    public class CreateMeetingResponse : BaseResponse
    {
        public string meetingID { get; set; }
        public string internalMeetingID { get; set; }
        public string parentMeetingID { get; set; }
        public string moderatorPW { get; set; }
        public string attendeePW { get; set; }
        public long createTime { get; set; }
        public int voiceBridge { get; set; }
        public string message { get; set; }
    }
}
