using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegEx_FindData
{
    public class KetQua
    {
        public int STT { get; set; }

        public string KetQuaMatch { get; set; }
    }

    public class LineSelect
    {
        public int STT { get; set; }

        public int index { get; set; }
        public int LengthSelect { get; set; }
    }
}