using BBB.NET.CORE.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBB.NET.CORE.Requests.User
{
    public class LockSettingsRequest : BaseRequest
    {
        public string meetingID { get; set; }
        public bool lockMicrophone { get; set; }
        public bool lockWebcams { get; set; }
        public bool lockChat { get; set; }
        public bool lockLayout { get; set; }
        public bool lockPrivateChat { get; set; }
        public bool lockPublicChat { get; set; }
        public bool lockSharedNotes { get; set; }
    }
}
