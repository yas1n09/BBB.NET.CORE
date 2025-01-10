using BBB.NET.CORE.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBB.NET.CORE.Responses.BreakoutRoom
{
    public class JoinBreakoutRoomResponse : BaseResponse
    {
        
        public string joinUrl { get; set; }
        public string message { get; set; }
        public bool Redirect { get; set; }

    }
}
