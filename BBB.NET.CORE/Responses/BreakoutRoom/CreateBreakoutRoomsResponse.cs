using BBB.NET.CORE.BaseClasses;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace BBB.NET.CORE.Responses.BreakoutRoom
{
    [XmlRoot("response")]
    public class CreateBreakoutRoomsResponse : BaseResponse
    {
        [XmlElement("parentMeetingID")]
        public string ParentMeetingID { get; set; }

        [XmlArray("breakoutRoomIDs")]
        [XmlArrayItem("breakoutRoomID")]
        public List<string> BreakoutRoomIDs { get; set; } = new List<string>();

    }
}
