﻿using BBB.NET.CORE.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBB.NET.CORE.Requests.BreakoutRoom
{
    public class GetBreakoutRoomInfoRequest :BaseRequest
    {
        public string breakoutRoomID { get; set; }
        public string password { get; set; }
    }
}
