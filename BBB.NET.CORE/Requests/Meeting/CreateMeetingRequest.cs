using BBB.NET.CORE.BaseClasses;
using BBB.NET.CORE.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BBB.NET.CORE.Requests.Meeting
{
    [Serializable, XmlRoot("request")]
    public class CreateMeetingRequest : BaseRequest
    {
        public string name { get; set; }
        public string meetingID { get; set; } = Guid.NewGuid().ToString();
        public int duration { get; set; } = 0;
        public bool record { get; set; } = false;
        public string moderatorPW { get; set; }
        public string attendeePW { get; set; } 
        public string welcome { get; set; } = "Welcome to the meeting!";
        public string dialNumber { get; set; }
        public int voiceBridge { get; set; }
        public int maxParticipants { get; set; } = 0;
        public bool? muteOnStart { get; set; }
        public bool? webcamsOnlyForModerator { get; set; }
        public string logoutURL { get; set; }
        public bool? allowOverrideClientSettingsOnCreateCall { get; set; }
        public bool? isBreakout { get; set; }
        public string parentMeetingID { get; set; } = "bbb-none";
        public int? sequence { get; set; }
        public MetaData meta { get; set; }
        public bool? freeJoin { get; set; }
        public bool? autoStartRecording { get; set; }
        public bool? allowStartStopRecording { get; set; }
        public string logo { get; set; }
        public string bannerText { get; set; }
        public string bannerColor { get; set; }
        public string copyright { get; set; }
        public bool? allowModsToUnmuteUsers { get; set; }
        public bool? lockSettingsDisableCam { get; set; }
        public bool? lockSettingsDisableMic { get; set; }
        public bool? lockSettingsDisablePrivateChat { get; set; }
        public bool? lockSettingsDisablePublicChat { get; set; }
        public bool? lockSettingsDisableNote { get; set; }
        public bool? lockSettingsLockedLayout { get; set; }
        public bool? lockSettingsLockOnJoin { get; set; }
        public bool? lockSettingsLockOnJoinConfigurable { get; set; }
        public string guestPolicy { get; set; } = "ALWAYS_ACCEPT";
    }

    [Serializable]
    public class MetaData
    {
        [XmlElement(ElementName = "meta_key")]
        public string key { get; set; }

        [XmlElement(ElementName = "meta_value")]
        public string value { get; set; }
    }















    //public string name { get; set; }
    //public string meetingID { get; set; }
    //public bool record { get; set; }
    //public bool? muteOnStart { get; set; }  // Başlangıçta tüm katılımcıları susturma
    //public bool? webcamsOnlyForModerator { get; set; }  // Sadece moderatör için webcam
    //public int duration { get; set; }
    //public int? maxParticipants { get; set; }

    // Aşağıdaki alanlar şimdilik devre dışı bırakıldı

    // public string logoutURL { get; set; }
    // public bool? allowOverrideClientSettingsOnCreateCall { get; set; }
    // public bool? isBreakout { get; set; }
    // public string parentMeetingID { get; set; }
    // public int? sequence { get; set; }
    // public MetaData meta { get; set; }
    // public bool? freeJoin { get; set; }
    // public bool? autoStartRecording { get; set; }
    // public bool? allowStartStopRecording { get; set; }
    // public string logo { get; set; }
    // public string bannerText { get; set; }
    // public string bannerColor { get; set; }
    // public string copyright { get; set; }
    // public bool? allowModsToUnmuteUsers { get; set; }
    // public bool? lockSettingsDisableCam { get; set; }
    // public bool? lockSettingsDisableMic { get; set; }
    // public bool? lockSettingsDisablePrivateChat { get; set; }
    // public bool? lockSettingsDisablePublicChat { get; set; }
    // public bool? lockSettingsDisableNote { get; set; }
    // public bool? lockSettingsLockedLayout { get; set; }
    // public bool? lockSettingsLockOnJoin { get; set; }
    // public bool? lockSettingsLockOnJoinConfigurable { get; set; }
    // public string guestPolicy { get; set; }
}

