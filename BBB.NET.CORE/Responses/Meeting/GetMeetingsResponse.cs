using BBB.NET.CORE.BaseClasses;
using BBB.NET.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BBB.NET.CORE.Responses.Meeting
{
    [Serializable, XmlRoot("response")]
    public class GetMeetingsResponse : BaseResponse
    {
        public List<MeetingInfo> meetings { get; set; }
        public string messageKey { get; set; }
        public string message { get; set; }
       
    }
}
