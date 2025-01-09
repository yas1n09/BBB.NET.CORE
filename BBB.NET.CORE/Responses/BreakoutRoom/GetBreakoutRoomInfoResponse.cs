using BBB.NET.CORE.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBB.NET.CORE.Responses.BreakoutRoom
{
    public class GetBreakoutRoomInfoResponse : BaseResponse
    {
        public string breakoutRoomID { get; set; }
        public string meetingName { get; set; }
        public int participantCount { get; set; }
        public int duration { get; set; }
        public long createTime { get; set; }
        public string message { get; set; }
    }
}
