using BBB.NET.CORE.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBB.NET.CORE.BaseClasses
{
    public class BaseResponse
    {
        public Returncode returncode { get; set; }
        public string messageKey { get; set; }
        public string message { get; set; }
    }
}
