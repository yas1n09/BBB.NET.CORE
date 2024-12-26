using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBB.NET.CORE.DTOs
{
    public class RecordingDto
    {
        public string recordID { get; set; }
        public string meetingID { get; set; }
        public bool published { get; set; }
        public long startTime { get; set; }
        public long endTime { get; set; }
        public string name { get; set; }
    }
}
