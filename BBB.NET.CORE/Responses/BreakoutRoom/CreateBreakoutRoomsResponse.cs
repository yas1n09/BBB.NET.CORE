using BBB.NET.CORE.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BBB.NET.CORE.Responses.BreakoutRoom
{
    [Serializable, XmlRoot("response")]
    public class CreateBreakoutRoomsResponse :BaseResponse
    {
        [XmlElement(ElementName = "parentMeetingID")]
        public string parentMeetingID { get; set; }

        [XmlArray("breakoutRoomIDs")]
        [XmlArrayItem("breakoutRoomID")]
        public List<string> breakoutRoomIDs { get; set; } = new List<string>();

        [XmlElement(ElementName = "message")]
        public string message { get; set; } = "Breakout rooms created successfully.";

    }
}
