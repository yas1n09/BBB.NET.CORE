﻿using BBB.NET.CORE.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBB.NET.CORE.Responses.Meeting
{
    public class IsMeetingRunningResponse : BaseResponse
    {
        public bool running { get; set; }
        public string meetingID { get; set; }
    }
}