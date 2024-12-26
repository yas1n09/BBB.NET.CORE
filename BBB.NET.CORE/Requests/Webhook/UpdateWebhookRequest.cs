using BBB.NET.CORE.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBB.NET.CORE.Requests.Webhook
{
    public class UpdateWebhookRequest : BaseRequest
    {
        public string webhookID { get; set; }
        public string callbackURL { get; set; }
        public string eventList { get; set; }
        public string description { get; set; }
    }
}
