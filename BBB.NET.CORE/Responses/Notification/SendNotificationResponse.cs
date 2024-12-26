using BBB.NET.CORE.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBB.NET.CORE.Responses.Notification
{
    public class SendNotificationResponse : BaseResponse
    {
        public string meetingID { get; set; }
        public bool sent { get; set; }
        public string message { get; set; }
    }
}
