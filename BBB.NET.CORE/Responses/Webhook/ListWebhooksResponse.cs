using BBB.NET.CORE.BaseClasses;
using BBB.NET.CORE.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBB.NET.CORE.Responses.Webhook
{
    public class ListWebhooksResponse : BaseResponse
    {
        public List<WebhookDto> webhooks { get; set; }
    }
}
