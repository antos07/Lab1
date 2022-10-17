using Lab1.Models.Cells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Models.Tables
{
    public class SimpleTable : ITable
    {
        private Dictionary<string, SimpleCell> _cells = new Dictionary<string, SimpleCell>();

        public int ColumnsNamber => 20;

        public int RowsNamber => 50;

        public ICell GetCell(string cell)
        {
            if (!_cells.ContainsKey(cell))
                _cells.Add(cell, new SimpleCell(this));
            return _cells[cell];
        }

        public Dictionary<string, ICell> ExportCells()
        {
            throw new NotImplementedException();
        }
    }
}
