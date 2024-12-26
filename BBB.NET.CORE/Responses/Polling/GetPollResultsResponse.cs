using BBB.NET.CORE.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBB.NET.CORE.Responses.Polling
{
    public class GetPollResultsResponse :BaseResponse
    {
        public string pollID { get; set; }
        public Dictionary<string, int> results { get; set; }  // Cevap ve oy sayısı
        public string message { get; set; }
    }
}
