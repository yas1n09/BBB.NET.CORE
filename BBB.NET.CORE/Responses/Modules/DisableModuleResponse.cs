using BBB.NET.CORE.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBB.NET.CORE.Responses.Modules
{
    public class DisableModuleResponse : BaseResponse
    {
        public string meetingID { get; set; }
        public string moduleName { get; set; }
        public bool disabled { get; set; }
        public string message { get; set; }
    }
}
