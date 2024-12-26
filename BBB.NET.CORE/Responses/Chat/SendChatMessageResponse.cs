using BBB.NET.CORE.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBB.NET.CORE.Responses.Chat
{
    public class SendChatMessageResponse : BaseResponse
    {
        public string meetingID { get; set; }
        public string messageID { get; set; }
        public bool sent { get; set; }
        public string message { get; set; }
    }
}
