﻿using BBB.NET.CORE.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBB.NET.CORE.Responses.Modules
{
    public class ListModulesResponse : BaseResponse
    {
        public string meetingID { get; set; }
        public List<ModuleDto> modules { get; set; }
    }
}
