using BBB.NET.CORE.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBB.NET.CORE.Requests.WhiteBoard
{
    public class EnableWhiteboardRequest : BaseRequest
    {
        public string meetingID { get; set; }
        public bool enable { get; set; }
    }
}
