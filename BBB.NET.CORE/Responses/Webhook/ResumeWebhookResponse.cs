﻿using BBB.NET.CORE.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBB.NET.CORE.Responses.Webhook
{
    public class ResumeWebhookResponse : BaseResponse
    {
        public string webhookID { get; set; }
        public bool resumed { get; set; }
        public string message { get; set; }
    }
}