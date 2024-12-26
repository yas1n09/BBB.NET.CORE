﻿using BBB.NET.CORE.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBB.NET.CORE.Requests.Translation
{
    public class RemoveTranslationRequest : BaseRequest
    {
        public string meetingID { get; set; }
        public string languageCode { get; set; }
    }
}