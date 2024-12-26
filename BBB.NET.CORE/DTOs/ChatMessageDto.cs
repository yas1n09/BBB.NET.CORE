using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBB.NET.CORE.DTOs
{
    public class ChatMessageDto
    {
        public string messageID { get; set; }
        public string sender { get; set; }
        public string content { get; set; }
        public long timestamp { get; set; }
    }
}
