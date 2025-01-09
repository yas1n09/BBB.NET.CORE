using BBB.NET.CORE.BaseClasses;
using BBB.NET.CORE.Entities;
using BBB.NET.CORE.Enums;
using BBB.NET.CORE.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BBB.NET.CORE.Responses.Meeting
{
    [Serializable, XmlRoot("response")]
    public class GetMeetingInfoResponse : MeetingInfo, IBaseResponse
    {








        //public string meetingID { get; set; }
        //public string meetingName { get; set; }
        //public int participantCount { get; set; }
        //public bool running { get; set; }
        //public long startTime { get; set; }
        //public long endTime { get; set; }
        public Returncode returncode { get; set; }
        // Mesaj anahtarının, uluslararasılaştırma veya özel mesajlara göre değişebileceğini belirten açıklama.
        public string messageKey { get; set; }

        // İşlem durumuyla ilgili ek bilgi sağlayan açıklama mesajı.
        public string message { get; set; }
    }
}
