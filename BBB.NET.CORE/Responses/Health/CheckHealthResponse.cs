using BBB.NET.CORE.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBB.NET.CORE.Responses.Health
{
    public class CheckHealthResponse : BaseResponse
    {
        public bool healthy { get; set; }
        public string message { get; set; }
        public long serverUptime { get; set; }
        public int activeMeetings { get; set; }
    }
}
