using BBB.NET.CORE.BaseClasses;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace BBB.NET.CORE.Responses.Meeting
{
    [Serializable, XmlRoot("response")]
    public class CreateMeetingResponse : BaseResponse
    {
        [XmlElement(ElementName = "meetingID")]
        public string meetingID { get; set; }

        [XmlElement(ElementName = "internalMeetingID")]
        public string internalMeetingID { get; set; }

        [XmlElement(ElementName = "parentMeetingID")]
        public string parentMeetingID { get; set; }

        [XmlElement(ElementName = "moderatorPW")]
        public string moderatorPW { get; set; }

        [XmlElement(ElementName = "attendeePW")]
        public string attendeePW { get; set; }

        [XmlElement(ElementName = "createTime")]
        public long createTime { get; set; }

        [XmlElement(ElementName = "voiceBridge")]
        public int? voiceBridge { get; set; }

        [XmlElement(ElementName = "dialNumber")]
        public string dialNumber { get; set; }

        [XmlElement(ElementName = "createDate")]
        public string createDate { get; set; }

        [XmlElement(ElementName = "hasUserJoined")]
        public bool hasUserJoined { get; set; }

        [XmlElement(ElementName = "duration")]
        public int duration { get; set; }

        [XmlElement(ElementName = "hasBeenForciblyEnded")]
        public bool hasBeenForciblyEnded { get; set; }

        [XmlElement(ElementName = "maxParticipants")]
        public int maxParticipants { get; set; }

        [XmlElement(ElementName = "participantCount")]
        public int participantCount { get; set; }

        [XmlElement(ElementName = "listenerCount")]
        public int listenerCount { get; set; }

        [XmlElement(ElementName = "voiceParticipantCount")]
        public int voiceParticipantCount { get; set; }

        [XmlElement(ElementName = "videoCount")]
        public int videoCount { get; set; }

        [XmlElement(ElementName = "recording")]
        public bool recording { get; set; }

        [XmlElement(ElementName = "hasBeenLocked")]
        public bool hasBeenLocked { get; set; }

        [XmlElement(ElementName = "hasStarted")]
        public bool hasStarted { get; set; }

        [XmlElement(ElementName = "running")]
        public string running { get; set; }

        [XmlElement(ElementName = "metadata")]
        public string metadata { get; set; }

        [XmlArray("attendeeList")]
        [XmlArrayItem("attendee")]
        public List<string> attendeeList { get; set; } = new List<string>();
    }
}
