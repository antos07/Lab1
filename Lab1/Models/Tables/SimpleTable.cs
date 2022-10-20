using Antlr4.Runtime.Dfa;
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
        private Dictionary<string, ICell> _cells = new Dictionary<string, ICell>();
        private long _trashhold = 50;

        public int ColumnsNumber { get; private set; } = 20;

        public int RowsNumber { get; private set; } = 50;

        public SimpleTable()
        { }

        public SimpleTable(int columnsNumber, int rowsNumber, Dictionary<string, ICell>? cells)
        {
            if (cells != null)
            {
                _cells = cells;
                ClearEmptyCells();
            }
            ColumnsNumber = columnsNumber;
            RowsNumber = rowsNumber;
        }

        public SimpleTable(int columnsNumber, int rowsNumber)
        {
            ColumnsNumber = columnsNumber;
            RowsNumber = rowsNumber;
        }

        public ICell GetCell(string cell)
        {
            CleanIfNeeded();
            if (!_cells.ContainsKey(cell))
                _cells.Add(cell, new SimpleCell(this));
            return _cells[cell];
        }

        public Dictionary<string, ICell> ExportCells()
        {
            ClearEmptyCells();
            return _cells;
        }

        private void CleanIfNeeded()
        {
            if (_cells.Count < _trashhold)
                return;
            ClearEmptyCells();
            while (_cells.Count > _trashhold)
                _trashhold *= 2;
            CleanIfNeeded();
        }

        private void ClearEmptyCells()
        {
            var toRemove = new List<string>();
            foreach (KeyValuePair<string, ICell> entry in _cells)
            {
                if (entry.Value.Expression == null)
                    toRemove.Add(entry.Key);
            }
            foreach (string key in toRemove)
                _cells.Remove(key);
        }
    }
}
