﻿using BBB.NET.CORE.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BBB.NET.CORE.Requests.Meeting
{
    [Serializable, XmlRoot("request")]
    public class GetMeetingsRequest : BaseRequest
    {
    }
}
