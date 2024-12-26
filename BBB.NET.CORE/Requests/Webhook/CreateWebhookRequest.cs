using BBB.NET.CORE.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBB.NET.CORE.Requests.Webhook
{
    public class CreateWebhookRequest : BaseRequest
    {
        public string callbackURL { get; set; }
        public string meetingID { get; set; }
        public string eventList { get; set; }  // Dinlenecek olaylar (örneğin, meeting-started)
        public string description { get; set; }
    }
}
