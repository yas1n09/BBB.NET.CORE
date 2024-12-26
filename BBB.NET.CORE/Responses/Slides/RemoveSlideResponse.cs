﻿using BBB.NET.CORE.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBB.NET.CORE.Responses.Slides
{
    public class RemoveSlideResponse : BaseResponse
    {
        public string meetingID { get; set; }
        public string slideID { get; set; }
        public bool removed { get; set; }
        public string message { get; set; }
    }
}
