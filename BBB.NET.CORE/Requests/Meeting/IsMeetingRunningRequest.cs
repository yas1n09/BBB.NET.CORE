﻿using BBB.NET.CORE.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBB.NET.CORE.Requests.Meeting
{
    public class IsMeetingRunningRequest : BaseRequest
    {
        public string meetingID { get; set; }
    }
}