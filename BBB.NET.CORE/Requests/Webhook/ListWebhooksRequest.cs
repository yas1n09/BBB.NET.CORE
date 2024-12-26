using BBB.NET.CORE.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBB.NET.CORE.Requests.Webhook
{
    public class ListWebhooksRequest : BaseRequest
    {
        public string meetingID { get; set; }  // Opsiyonel - Belirli bir toplantıya ait webhook'ları listeler
    }
}
