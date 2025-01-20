using BBB.NET.CORE.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BBB.NET.CORE.BaseClasses
{
    [XmlRoot("response")]
    public class BaseResponse
    {
        [XmlElement("returncode")]
        public Returncode returncode { get; set; }
        [XmlElement("messageKey")]
        public string messageKey { get; set; }
        [XmlElement("message")]
        public string message { get; set; }
    }
}
