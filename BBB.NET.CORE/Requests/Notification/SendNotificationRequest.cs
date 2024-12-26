using BBB.NET.CORE.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBB.NET.CORE.Requests.Notification
{
    public class SendNotificationRequest :BaseRequest
    {
        public string meetingID { get; set; }
        public string notificationType { get; set; }
        public string message { get; set; }
    }
}
