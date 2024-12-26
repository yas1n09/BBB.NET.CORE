using BBB.NET.CORE.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBB.NET.CORE.Responses.Polling
{
    public class StartPollResponse :BaseResponse
    {
        public string pollID { get; set; }
        public string meetingID { get; set; }
        public bool started { get; set; }
        public string message { get; set; }
    }
}
