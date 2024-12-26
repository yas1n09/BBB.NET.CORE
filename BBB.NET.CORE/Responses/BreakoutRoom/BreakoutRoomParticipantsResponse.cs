using BBB.NET.CORE.BaseClasses;
using BBB.NET.CORE.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBB.NET.CORE.Responses.BreakoutRoom
{
    public class BreakoutRoomParticipantsResponse : BaseResponse
    {
        public string breakoutRoomID { get; set; }
        public List<BreakoutRoomParticipantDto> participants { get; set; }
    }
}
