﻿using BBB.NET.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBB.NET.CORE.BaseClasses
{
    public class BasePostFileRequest : BaseRequest
    {
        public FileContentData file { get; set; }
    }
}
