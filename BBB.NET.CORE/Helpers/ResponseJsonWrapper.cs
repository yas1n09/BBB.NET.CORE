﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBB.NET.CORE.Helpers
{
    public class ResponseJsonWrapper<T>
    {
        public T response { get; set; } // Yanıt (response) özelliği.
    }
}