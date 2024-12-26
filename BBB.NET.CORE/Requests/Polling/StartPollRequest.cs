using BBB.NET.CORE.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBB.NET.CORE.Requests.Polling
{
    public class StartPollRequest : BaseRequest
    {
        public string meetingID { get; set; }
        public string pollType { get; set; }  // Örn: YES_NO, MULTIPLE_CHOICE
        public List<string> answers { get; set; }
    }
}
