using BBB.NET.CORE.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BBB.NET.CORE.Requests.Meeting
{
    [Serializable, XmlRoot("request")]
    public class JoinMeetingRequest : BaseRequest
    {
        public string fullName { get; set; }
        public string meetingID { get; set; }
        
        public string password { get; set; }
        public string createTime { get; set; }
        public string userID { get; set; }
        public string webVoiceConf { get; set; }
        public string configToken { get; set; }


        public string userdata;

        
        // Opsiyonel.
        // Uygulama yüklendiğinde ilk olarak yüklenecek düzenin adı.
        public string defaultLayout { get; set; }

        // Opsiyonel.
        // Kullanıcı avatarını, config.xml dosyasında displayAvatar true olarak ayarlandığında göstermek için avatar URL'si.
        public string avatarURL { get; set; }

        // Opsiyonel (Deneysel).
        // Varsayılan JOIN API davranışı, başarılı bir katılım çağrısında Flash istemcisine yönlendirmedir. FALSE olarak ayarlandığında, yönlendirme yapılmaz ve XML döndürülür.
        public bool? redirect { get; set; }

        // Opsiyonel (Deneysel).
        // Özel istemci uygulamaları için, yönlendirme yapılmadığında özel istemci URL'si belirlenebilir.
        public string clientURL { get; set; }

        // Opsiyonel.
        // HTML5 istemcisinin kullanıcı için yüklenmesi gerektiğini belirtir.
        public bool? joinViaHtml5 { get; set; }

        // Opsiyonel.
        // Kullanıcının misafir olduğunu belirtir.
        public bool? guest { get; set; }
    }
}
