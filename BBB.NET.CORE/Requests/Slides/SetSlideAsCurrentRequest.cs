using BBB.NET.CORE.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBB.NET.CORE.Requests.Slides
{
    public class SetSlideAsCurrentRequest : BaseRequest
    {
        public string meetingID { get; set; }
        public string slideID { get; set; }
    }
}
