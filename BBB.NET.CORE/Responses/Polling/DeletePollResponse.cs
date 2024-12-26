﻿using BBB.NET.CORE.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBB.NET.CORE.Responses.Polling
{
    public class DeletePollResponse : BaseResponse
    {
        public string pollID { get; set; }
        public bool deleted { get; set; }
        public string message { get; set; }
    }
}
