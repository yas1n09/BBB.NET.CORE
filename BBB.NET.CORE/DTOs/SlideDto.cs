using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBB.NET.CORE.DTOs
{
    public class SlideDto
    {
        public string slideID { get; set; }
        public string slideName { get; set; }
        public int order { get; set; }
        public bool isCurrent { get; set; }
    }
}
