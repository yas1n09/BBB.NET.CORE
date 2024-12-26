using BBB.NET.CORE.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBB.NET.CORE.Responses.Meeting
{
    public class EndMeetingResponse : BaseResponse
    {
        public string meetingID { get; set; }
        public bool ended { get; set; }
        public string message { get; set; }
    }
}
