﻿using BBB.NET.CORE.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BBB.NET.CORE.Responses.Meeting
{
    [XmlRoot("response")]
    public class IsMeetingRunningResponse : BaseResponse
    {
        public bool? running { get; set; }
        public string message { get; set; } // Ek bilgi için alan eklendi
        public string meetingID { get; set; } // Yanıta toplantı ID'si eklendi
    }
}
