﻿using BBB.NET.CORE.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBB.NET.CORE.Responses.Meeting
{
    internal class JoinMeetingResponse : BaseResponse
    {
        public string meetingID { get; set; }
        public string joinUrl { get; set; }
        public string message { get; set; }
    }
}
