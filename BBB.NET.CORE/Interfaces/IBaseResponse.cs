using BBB.NET.CORE.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBB.NET.CORE.Interfaces
{
    public interface IBaseResponse
    {
        Returncode returncode { get; set; }
        string messageKey { get; set; }
        string message { get; set; }

    }
}
