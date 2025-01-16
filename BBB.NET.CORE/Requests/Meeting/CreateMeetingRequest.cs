using BBB.NET.CORE.BaseClasses;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace BBB.NET.CORE.Requests.Meeting
{
    [Serializable, XmlRoot("request")]
    public class CreateMeetingRequest : BaseRequest
    {
        [XmlElement(ElementName = "name", IsNullable = false)]
        public string name { get; set; } // Toplantı adı (Zorunlu)

        [XmlElement(ElementName = "meetingID")]
        public string meetingID { get; set; } = Guid.NewGuid().ToString(); // Benzersiz toplantı ID'si

        [XmlElement(ElementName = "duration")]
        public int duration { get; set; } = 0; // Toplantı süresi (dakika)

        [XmlElement(ElementName = "record")]
        public bool record { get; set; } = false; // Kayıt özelliği açık mı?

        [XmlElement(ElementName = "moderatorPW", IsNullable = false)]
        public string moderatorPW { get; set; } // Moderatör şifresi (Zorunlu)

        [XmlElement(ElementName = "attendeePW", IsNullable = false)]
        public string attendeePW { get; set; } // Katılımcı şifresi (Zorunlu)

        [XmlElement(ElementName = "welcome")]
        public string welcome { get; set; } = "Welcome to the meeting!"; // Karşılama mesajı

        [XmlElement(ElementName = "dialNumber")]
        public string dialNumber { get; set; } // Toplantı telefon numarası

        [XmlElement(ElementName = "voiceBridge")]
        public int voiceBridge { get; set; } // Ses köprüsü numarası

        [XmlElement(ElementName = "maxParticipants")]
        public int maxParticipants { get; set; } = 0; // Maksimum katılımcı sayısı (0: sınırsız)

        [XmlElement(ElementName = "muteOnStart")]
        public bool? muteOnStart { get; set; } // Başlangıçta tüm katılımcıları susturma

        [XmlElement(ElementName = "webcamsOnlyForModerator")]
        public bool? webcamsOnlyForModerator { get; set; } // Sadece moderatör için webcam

        [XmlElement(ElementName = "logoutURL")]
        public string logoutURL { get; set; } // Çıkış URL'si

        [XmlElement(ElementName = "allowOverrideClientSettingsOnCreateCall")]
        public bool? allowOverrideClientSettingsOnCreateCall { get; set; } // Ayarları geçersiz kılma

        [XmlElement(ElementName = "isBreakout")]
        public bool? isBreakout { get; set; } // Breakout toplantısı mı?

        [XmlElement(ElementName = "parentMeetingID")]
        public string parentMeetingID { get; set; } = "bbb-none"; // Ana toplantı ID'si

        [XmlElement(ElementName = "sequence")]
        public int? sequence { get; set; } // Sıralama değeri

        [XmlElement(ElementName = "meta")]
        public List<MetaData> meta { get; set; } = new List<MetaData>(); // Meta veriler

        [XmlElement(ElementName = "freeJoin")]
        public bool? freeJoin { get; set; } // Şifre gerekmeden katılım

        [XmlElement(ElementName = "autoStartRecording")]
        public bool? autoStartRecording { get; set; } // Toplantı başlangıcında kayıt başlatma

        [XmlElement(ElementName = "allowStartStopRecording")]
        public bool? allowStartStopRecording { get; set; } // Kayıt başlat/durdur izni

        [XmlElement(ElementName = "logo")]
        public string logo { get; set; } // Toplantı logosu URL'si

        [XmlElement(ElementName = "bannerText")]
        public string bannerText { get; set; } // Banner metni

        [XmlElement(ElementName = "bannerColor")]
        public string bannerColor { get; set; } // Banner rengi

        [XmlElement(ElementName = "copyright")]
        public string copyright { get; set; } // Telif hakkı bilgisi

        [XmlElement(ElementName = "allowModsToUnmuteUsers")]
        public bool? allowModsToUnmuteUsers { get; set; } // Moderatörlerin katılımcıları susturmayı kaldırmasına izin

        [XmlElement(ElementName = "lockSettingsDisableCam")]
        public bool? lockSettingsDisableCam { get; set; } // Kamera kullanımını engelle

        [XmlElement(ElementName = "lockSettingsDisableMic")]
        public bool? lockSettingsDisableMic { get; set; } // Mikrofon kullanımını engelle

        [XmlElement(ElementName = "lockSettingsDisablePrivateChat")]
        public bool? lockSettingsDisablePrivateChat { get; set; } // Özel sohbeti engelle

        [XmlElement(ElementName = "lockSettingsDisablePublicChat")]
        public bool? lockSettingsDisablePublicChat { get; set; } // Genel sohbeti engelle

        [XmlElement(ElementName = "lockSettingsDisableNote")]
        public bool? lockSettingsDisableNote { get; set; } // Not kullanımını engelle

        [XmlElement(ElementName = "lockSettingsLockedLayout")]
        public bool? lockSettingsLockedLayout { get; set; } // Kilitli düzen

        [XmlElement(ElementName = "lockSettingsLockOnJoin")]
        public bool? lockSettingsLockOnJoin { get; set; } // Katılımcı girişinde kilit

        [XmlElement(ElementName = "lockSettingsLockOnJoinConfigurable")]
        public bool? lockSettingsLockOnJoinConfigurable { get; set; } // Girişte kilit ayarı yapılandırılabilir mi?

        [XmlElement(ElementName = "guestPolicy")]
        public string guestPolicy { get; set; } = "ALWAYS_ACCEPT"; // Misafir politikası
    }

    [Serializable]
    public class MetaData
    {
        [XmlElement(ElementName = "meta_key")]
        public string key { get; set; }

        [XmlElement(ElementName = "meta_value")]
        public string value { get; set; }
    }
}
