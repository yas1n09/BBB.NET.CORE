using BBB.NET.CORE.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBB.NET.CORE.Responses.Reporting
{
    public class ExportMeetingDataResponse : BaseResponse
    {
        public string meetingID { get; set; }
        public bool exported { get; set; }
        public string fileURL { get; set; }
        public string message { get; set; }
    }
}
