using BBB.NET.CORE.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBB.NET.CORE.Responses.RecordingTextTracks
{
    public class GetRecordingInfoResponse : BaseResponse
    {
        public string recordID { get; set; }
        public string meetingID { get; set; }
        public long startTime { get; set; }
        public long endTime { get; set; }
        public bool published { get; set; }
        public string name { get; set; }
        public List<string> playbackFormats { get; set; }
        public string message { get; set; }
    }
}
