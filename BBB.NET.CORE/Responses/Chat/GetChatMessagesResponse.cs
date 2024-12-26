﻿using BBB.NET.CORE.BaseClasses;
using BBB.NET.CORE.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBB.NET.CORE.Responses.Chat
{
    public class GetChatMessagesResponse : BaseResponse
    {
        public string meetingID { get; set; }
        public List<ChatMessageDto> messages { get; set; }
    }
}