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
    public class CreateMeetingResponse : BaseResponse
    {
        
        
       public int maxParticipants { get; set; }
        public string meetingID { get; set; }
        public string internalMeetingID { get; set; }
        public string parentMeetingID { get; set; }
        public string moderatorPW { get; set; }
        public string attendeePW { get; set; }
        public long createTime { get; set; }
        public int? voiceBridge { get; set; }
        public string dialNumber { get; set; }
        public string createDate { get; set; }
        public bool hasUserJoined { get; set; }
        public int duration { get; set; }
        public bool hasBeenForciblyEnded { get; set; }
        public int participantCount { get; set; }
        public int listenerCount { get; set; }
        public int voiceParticipantCount { get; set; }
        public int videoCount { get; set; }
        public bool recording { get; set; }
        public bool hasBeenLocked { get; set; }
        public bool hasStarted { get; set; }
        public string running { get; set; }
        public string metadata { get; set; }
        public string[] attendeeList { get; set; }































        //////////////
        //// Toplantı kimliği.
        //public string meetingID { get; set; }

        //// Sistem tarafından kullanılan dahili toplantı kimliği.
        //public string internalMeetingID { get; set; }

        //// Ana toplantı kimliği.
        //public string parentMeetingID { get; set; }

        //// Katılımcıların, URL üzerinden katılacağı şifreyi belirten şifre.
        //public string attendeePW { get; set; }

        //// Moderatör şifresi.
        //public string moderatorPW { get; set; }

        //// Toplantının oluşturulma zamanı.
        //public long? createTime { get; set; }

        //// FreeSWITCH ses konferans numarası.
        //public int? voiceBridge { get; set; }

        //// Katılımcıların arayabileceği telefon numarası.
        //public string dialNumber { get; set; }

        //// Toplantının oluşturulma tarihi.
        //public string createDate { get; set; }

        //// Kullanıcıların katılıp katılmadığı durumu.
        //public bool? hasUserJoined { get; set; }

        //// Toplantının süresi.
        //public int? duration { get; set; }

        //// Toplantının zorla sonlandırılıp sonlandırılmadığı.
        //public bool? hasBeenForciblyEnded { get; set; }

        //public int maxParticipants { get; set; }

        //public string message { get; set; } = "Meeting created successfully.";



    }
}
