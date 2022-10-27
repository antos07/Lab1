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
        public int ColumnsNumber { get; }

        public int RowsNumber { get; }

        public ICell GetCell(string cell);

        public Dictionary<string, ICell> ExportCells();

        public void DeleteRow(string rowId);

        public void DeleteColumn(string columnId);

        public void InsertRow(string desiredRowId);

        public void InsertColumn(string desiredColumnId);
    }
}
