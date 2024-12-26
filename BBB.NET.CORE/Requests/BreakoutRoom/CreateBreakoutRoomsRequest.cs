using BBB.NET.CORE.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBB.NET.CORE.Requests.BreakoutRoom
{
    public class CreateBreakoutRoomsRequest : BaseRequest
    {
        public string meetingID { get; set; }
        public int roomCount { get; set; }
        public int durationInMinutes { get; set; }
        public List<string> attendeeIDs { get; set; }
    }
}
