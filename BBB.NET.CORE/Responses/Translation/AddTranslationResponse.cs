using BBB.NET.CORE.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBB.NET.CORE.Responses.Translation
{
    public class AddTranslationResponse : BaseResponse
    {
        public string meetingID { get; set; }
        public string languageCode { get; set; }
        public bool added { get; set; }
        public string message { get; set; }
    }
}
