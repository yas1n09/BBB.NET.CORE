using BBB.NET.CORE.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBB.NET.CORE.Requests.AuditLogs
{
    public class ExportAuditLogsRequest :BaseRequest
    {
        public string meetingID { get; set; }
        public string format { get; set; }  // Örn: JSON, CSV
    }
}
