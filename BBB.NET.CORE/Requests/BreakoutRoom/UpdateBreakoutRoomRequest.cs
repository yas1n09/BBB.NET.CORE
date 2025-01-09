using BBB.NET.CORE.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBB.NET.CORE.Requests.BreakoutRoom
{
    public class UpdateBreakoutRoomRequest : BaseRequest
    {
        public string breakoutRoomID { get; set; }
        public int durationInMinutes { get; set; }
        public List<string> attendeeIDs { get; set; }
        public string moderatorPW { get; set; }
        public string attendeePW { get; set; }
    }
}
