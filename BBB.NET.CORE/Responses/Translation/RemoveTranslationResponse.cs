using BBB.NET.CORE.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBB.NET.CORE.Responses.Translation
{
    public class RemoveTranslationResponse : BaseResponse
    {
        public string meetingID { get; set; }
        public bool removed { get; set; }
        public string message { get; set; }
    }
}
