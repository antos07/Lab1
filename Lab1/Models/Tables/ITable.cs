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
        public ICell GetCell(string cell);

        public Dictionary<string, ICell> ExportCells();
    }
}
