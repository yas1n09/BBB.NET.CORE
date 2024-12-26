using BBB.NET.CORE.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBB.NET.CORE.Responses.Notification
{
    public class GetNotificationStatusResponse : BaseResponse
    {
        public string notificationID { get; set; }
        public string status { get; set; }
        public string message { get; set; }
    }
}
