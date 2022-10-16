using Lab1.Models.Cells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Models.Tables
{
    public interface ITable
    {
        public int ColumnsNamber { get; }

        public int RowsNamber { get; }

        public ICell GetCell(string cell);

        public Dictionary<string, ICell> ExportCells();
    }
}
