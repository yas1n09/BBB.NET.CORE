using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BBB.NET.CORE.DTOs
{
    [XmlRoot("response")]
    public class BreakoutRoomCreateDto
    {
        public string MeetingID { get; set; }
        public string Name { get; set; }
        public string AttendeePW { get; set; }
        public string ModeratorPW { get; set; }
        public int Duration { get; set; }
        public bool Redirect { get; set; }
        public string Message { get; set; }
    }
}
