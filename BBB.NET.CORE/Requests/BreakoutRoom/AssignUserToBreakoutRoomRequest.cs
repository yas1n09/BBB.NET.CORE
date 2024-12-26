using BBB.NET.CORE.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBB.NET.CORE.Requests.BreakoutRoom
{
    public class AssignUserToBreakoutRoomRequest :BaseRequest
    {
        public string parentMeetingID { get; set; }
        public string breakoutRoomID { get; set; }
        public string userID { get; set; }
    }
}
