﻿using BBB.NET.CORE.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBB.NET.CORE.Requests.Recording
{
    public class PublishRecordingsRequest : BaseRequest
    {
        public string recordID { get; set; }
        public bool publish { get; set; }
    }
}