using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BBB.NET.CORE.Enums
{
    /// <summary>
    /// BigBlueButton API çağrılarında döndürülen işlem durumu.
    /// </summary>
    public enum Returncode
    {
        [XmlEnum("SUCCESS")]
        SUCCESS = 0,

        [XmlEnum("FAILED")]
        FAILED = 1
    }
}
