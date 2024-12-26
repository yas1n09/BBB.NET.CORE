using BBB.NET.CORE.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBB.NET.CORE.Responses.Recording
{
    public class PublishRecordingsResponse : BaseResponse
    {
        public string recordID { get; set; }
        public bool published { get; set; }
        public string message { get; set; }
    }
}
