﻿using BBB.NET.CORE.BaseClasses;
using BBB.NET.CORE.Requests.Meeting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBB.NET.CORE.Requests.BreakoutRoom
{
    public class JoinBreakoutRoomRequest : JoinMeetingRequest
    {
        public string breakoutRoomID { get; set; }
        public string fullName { get; set; }
        public string password { get; set; }
        //public bool redirect { get; set; }

    }
}
