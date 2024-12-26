using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBB.NET.CORE.DTOs
{
    public class PollDto
    {
        public string pollID { get; set; }
        public string pollType { get; set; }
        public bool active { get; set; }
        public Dictionary<string, int> results { get; set; }
    }
}
