using BBB.NET.CORE.BaseClasses;
using BBB.NET.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBB.NET.CORE.Responses.BreakoutRoom
{
    public class GetBreakoutRoomsResponse : BaseResponse
    {
        public string parentMeetingID { get; set; }
        public List<string> breakoutRoomIDs { get; set; }
        public List<string> breakoutRooms { get; set; } // Yeni özellik
        public string message { get; set; }
        public List<BreakoutRoomInfo> BreakoutRoomInfos { get; set; }

    }
}
