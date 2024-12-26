using BBB.NET.CORE.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBB.NET.CORE.Responses.BreakoutRoom
{
    public class CreateBreakoutRoomsResponse :BaseResponse
    {
        public string parentMeetingID { get; set; }
        public List<string> breakoutRoomIDs { get; set; }
        public string message { get; set; }
    }
}
