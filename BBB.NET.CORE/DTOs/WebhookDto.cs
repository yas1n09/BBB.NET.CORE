using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBB.NET.CORE.DTOs
{
    public class WebhookDto
    {
        public string webhookID { get; set; }
        public string callbackURL { get; set; }
        public string meetingID { get; set; }
        public string eventList { get; set; }
        public string description { get; set; }
        public long createdAt { get; set; }
    }
}
