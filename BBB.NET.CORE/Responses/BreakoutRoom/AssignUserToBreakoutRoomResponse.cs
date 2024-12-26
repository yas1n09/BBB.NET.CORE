using BBB.NET.CORE.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBB.NET.CORE.Responses.BreakoutRoom
{
    public class AssignUserToBreakoutRoomResponse :BaseResponse
    {
        public string breakoutRoomID { get; set; }
        public string userID { get; set; }
        public bool assigned { get; set; }
        public string message { get; set; }
    }
}
