using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBB.NET.CORE.DTOs
{
    public class AuditLogDto
    {
        public string eventName { get; set; }
        public string userID { get; set; }
        public string description { get; set; }
        public long timestamp { get; set; }
    }
}
