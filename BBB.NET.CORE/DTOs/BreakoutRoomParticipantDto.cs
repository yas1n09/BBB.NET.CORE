using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBB.NET.CORE.DTOs
{
    public class BreakoutRoomParticipantDto
    {
        public string userID { get; set; }
        public string fullName { get; set; }
        public string role { get; set; }
        public bool isModerator { get; set; }
        public bool hasVideo { get; set; }
        public bool hasJoinedVoice { get; set; }
    }
}
