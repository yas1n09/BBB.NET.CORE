using BBB.NET.CORE.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBB.NET.CORE.Requests.Meeting
{
    public class JoinMeetingRequest : BaseRequest
    {
        public string meetingID { get; set; }
        public string fullName { get; set; }
        public string password { get; set; }
        public string createTime { get; set; }
        public string userID { get; set; }
        public string webVoiceConf { get; set; }
        public string configToken { get; set; }
    }
}
