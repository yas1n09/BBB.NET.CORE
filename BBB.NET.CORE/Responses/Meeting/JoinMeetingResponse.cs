using BBB.NET.CORE.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BBB.NET.CORE.Responses.Meeting
{
    [Serializable, XmlRoot("response")]
    public class JoinMeetingResponse : BaseResponse
    {
        public string meetingID { get; set; }
        public string JoinUrl { get; set; }
        public bool Redirect { get; set; }
        public string Message { get; set; }
    }
}
