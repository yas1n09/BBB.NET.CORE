using BBB.NET.CORE.BaseClasses;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace BBB.NET.CORE.Requests.BreakoutRoom
{
    [Serializable, XmlRoot("request")]
    
    public class CreateBreakoutRoomRequest : BaseRequest
    {

        [XmlElement("name")]
        public string Name { get; set; } // Toplantı adı

        [XmlElement("meetingID")]
        public string MeetingID { get; set; } // Toplantı kimliği

        [XmlElement("attendeePW")]
        public string AttendeePassword { get; set; } // Katılımcı parolası

        [XmlElement("moderatorPW")]
        public string ModeratorPassword { get; set; } // Moderatör parolası

        [XmlElement("duration")]
        public int Duration { get; set; } = 60; // Toplantı süresi (dakika cinsinden)

        [XmlElement("isBreakout")]
        public bool IsBreakout { get; set; } = true; // Breakout odası olduğunu belirtir

        [XmlElement("parentMeetingID")]
        public string ParentMeetingID { get; set; } // Ana toplantının kimliği

        [XmlElement("sequence")]
        public int Sequence { get; set; } = 1; // Breakout odasının sıra numarası

        [XmlElement("freeJoin")]
        public bool FreeJoin { get; set; } = true; // Katılımcıların serbestçe katılabilmesi

        // Diğer isteğe bağlı parametreler burada tanımlanabilir

    }
}
