using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBB.NET.CORE.Entities
{
    public class FileContentData
    {
        public string Name { get; set; } // HTTP içeriğinin adı.

        public string FileName { get; set; } // HTTP içeriği için dosya adı.

        public byte[] FileData { get; set; } // Dosya verileri.
    }
}
