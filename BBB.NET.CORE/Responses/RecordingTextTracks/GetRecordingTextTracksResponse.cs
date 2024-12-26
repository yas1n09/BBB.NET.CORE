using BBB.NET.CORE.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBB.NET.CORE.Responses.RecordingTextTracks
{
    public class GetRecordingTextTracksResponse : BaseResponse
    {
        public string recordID { get; set; }
        public List<string> textTracks { get; set; }
        public string message { get; set; }
    }
}
