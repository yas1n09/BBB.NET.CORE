using BBB.NET.CORE.BaseClasses;
using BBB.NET.CORE.DTOs;
using BBB.NET.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBB.NET.CORE.Responses.Recording
{
    public class GetRecordingsResponse : BaseResponse
    {
        public List<RecordingDto> recordings { get; set; }
        public string messageKey { get; set; }
        public string message { get; set; }
    }
}
