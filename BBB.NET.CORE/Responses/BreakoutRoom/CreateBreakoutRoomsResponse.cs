using BBB.NET.CORE.BaseClasses;
using BBB.NET.CORE.Enums;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace BBB.NET.CORE.Responses.BreakoutRoom
{
    [Serializable, XmlRoot("response")]
    public class CreateBreakoutRoomsResponse : BaseResponse
    {

        [XmlIgnore]
        public string Status => returncode == Returncode.SUCCESS ? "Success" : "Failed";


        [XmlElement("meetingID")]
        public string MeetingID { get; set; } // Oluşturulan toplantının kimliği

        [XmlElement("attendeePW")]
        public string AttendeePassword { get; set; } // Katılımcı parolası

        [XmlElement("moderatorPW")]
        public string ModeratorPassword { get; set; } // Moderatör parolası

        [XmlElement("createTime")]
        public long CreateTime { get; set; } // Oluşturulma zamanı (Unix zaman damgası)

        [XmlElement("voiceBridge")]
        public string VoiceBridge { get; set; } // Ses köprüsü numarası

        [XmlElement("dialNumber")]
        public string DialNumber { get; set; } // Arama numarası

        [XmlElement("createDate")]
        public string CreateDate { get; set; } // Oluşturulma tarihi

        [XmlElement("hasUserJoined")]
        public bool HasUserJoined { get; set; } // Kullanıcıların katılıp katılmadığı

        [XmlElement("duration")]
        public int Duration { get; set; } // Toplantı süresi

        [XmlElement("hasBeenForciblyEnded")]
        public bool HasBeenForciblyEnded { get; set; } // Zorla sonlandırılıp sonlandırılmadığı

    }
}
