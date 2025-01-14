using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BBB.NET.CORE.DTOs
{
    [XmlRoot("response")]
    public class AllMeetingsDto
    {
        public string Message { get; set; }
        public List<MeetingInfoDto> Meetings { get; set; }
    }
}
