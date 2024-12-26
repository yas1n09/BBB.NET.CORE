using BBB.NET.CORE.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBB.NET.CORE.Responses.User
{
    public class MuteUserResponse : BaseResponse
    {
        public string meetingID { get; set; }
        public string userID { get; set; }
        public bool muted { get; set; }
        public string message { get; set; }
    }
}
