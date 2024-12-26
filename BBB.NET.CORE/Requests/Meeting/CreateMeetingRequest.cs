using BBB.NET.CORE.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBB.NET.CORE.Requests.Meeting
{
    public class CreateMeetingRequest : BaseRequest
    {
        public string name { get; set; }
        public string meetingID { get; set; }
        public bool record { get; set; }
        public int duration { get; set; }
        public string moderatorPW { get; set; }
        public string attendeePW { get; set; }
        public string welcome { get; set; }
        public string dialNumber { get; set; }
    }
}
