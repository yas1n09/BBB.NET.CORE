using BBB.NET.CORE.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBB.NET.CORE.Responses.Webhook
{
    public class CreateWebhookResponse : BaseResponse
    {
        public string webhookID { get; set; }
        public string meetingID { get; set; }
        public bool created { get; set; }
        public string message { get; set; }
    }
}
