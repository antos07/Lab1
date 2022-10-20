using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Utils
{
    public class TableJson
    {
        public int ColumnsNumber { get; set; }
        public int RowsNumber { get; set; }
        public Dictionary<string, string?> Cells { get; set; } = new Dictionary<string, string?>();
    }
}
