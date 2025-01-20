using BBB.NET.CORE.BaseClasses;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace BBB.NET.CORE.Requests.BreakoutRoom
{
    [XmlRoot("createBreakoutRoomsRequest")]
    public class CreateBreakoutRoomRequest : BaseRequest
    {
        [XmlElement("parentMeetingID")]
        public string ParentMeetingID { get; set; }

        [XmlElement("roomCount")]
        public int RoomCount { get; set; }

        [XmlElement("durationInMinutes")]
        public int DurationInMinutes { get; set; }

        [XmlArray("attendeeIDs")]
        [XmlArrayItem("attendeeIDs")]
        public List<string> AttendeeIDs { get; set; } = new List<string>();

        [XmlElement("moderatorPW")]
        public string ModeratorPW { get; set; }

        [XmlElement("attendeePW")]
        public string AttendeePW { get; set; }

        [XmlElement("name")]
        public string Name { get; set; } = "Breakout Room";

        [XmlElement("redirect")]
        public bool Redirect { get; set; } = true;
    }
}
