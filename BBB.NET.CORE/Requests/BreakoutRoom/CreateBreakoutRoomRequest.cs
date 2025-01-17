using BBB.NET.CORE.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BBB.NET.CORE.Requests.BreakoutRoom
{
    [Serializable, XmlRoot("CreateBreakoutRoomRequest")]
    public class CreateBreakoutRoomRequest : BaseRequest
    {
        [XmlElement(ElementName = "parentMeetingID")]
        public string parentMeetingID { get; set; }

        [XmlElement(ElementName = "roomCount")]
        public int roomCount { get; set; }

        [XmlElement(ElementName = "durationInMinutes")]
        public int durationInMinutes { get; set; }

        [XmlArray("attendeeIDs")]
        [XmlArrayItem("attendeeID")]
        public List<string> attendeeIDs { get; set; } = new List<string>();

        [XmlElement(ElementName = "moderatorPW")]
        public string moderatorPW { get; set; }

        [XmlElement(ElementName = "attendeePW")]
        public string attendeePW { get; set; }

        [XmlElement(ElementName = "name")]
        public string name { get; set; }

        [XmlElement(ElementName = "redirect")]
        public bool redirect { get; set; }
    }
}
