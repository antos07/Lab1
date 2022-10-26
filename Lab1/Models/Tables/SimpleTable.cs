using Antlr4.Runtime.Dfa;
using Lab1.Models.Cells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        public void DeleteRow(string rowId)
        {
            RemoveCellsWithRowId(rowId);
            int rowIndex = GetRowIndex(rowId);
            ShiftRowIdForPredicate(rowId1 => GetRowIndex(rowId1) > rowIndex, -1);
        }

        public void DeleteColumn(string columnId)
        {
            RemoveCellsWithColumnId(columnId);
            int columnIndex = GetColumnIndex(columnId);
            ShiftColumnIdForPredicate(columnId1 => GetColumnIndex(columnId1) > columnIndex, -1);
        }

        private void RemoveCellsWithRowId(string rowId)
        {
            var cellsToDelete = _cells.Keys.Where(cellId => GetRowId(cellId) == rowId).ToList();
            foreach (var cell in cellsToDelete)
                _cells.Remove(cell);
        }

        private void RemoveCellsWithColumnId(string columnId)
        {
            var cellsToDelete = _cells.Keys.Where(cellId => GetColumnId(cellId) == columnId).ToList();
            foreach (var cell in cellsToDelete)
                _cells.Remove(cell);
        }

        private string GetRowId(string cellId)
        {
            return Regex.Match(cellId, @"\d+").Value;
        }

        private string GetRowId(int rowIndex)
        {
            return rowIndex.ToString();
        }

        private string GetColumnId(string cellId)
        {
            return Regex.Match(cellId, @"[A-Z]+").Value;
        }

        private string GetColumnId(int columnIndex)
        {
            string result = "";
            while (columnIndex > 0)
            {
                result += 'A' + columnIndex % 26;
                columnIndex %= 26;
            }
            return result;
        }

        private int GetRowIndex(string rowId) => Convert.ToInt32(rowId);

        private int GetColumnIndex(string columnId)
        {
            int index = 0;
            for (int i = columnId.Length - 1; i >= 0; i--)
            {
                index *= 26;
                index += columnId[i] - 'A';
            }
            return index;
        }

        private void ShiftRowIdForPredicate(Func<string, bool> predicate, int shift)
        {
            ShiftRowIdForPredicateCells(predicate, shift);
            ShiftRowIdForPredicateReferences(predicate, shift);
        }

        private void ShiftRowIdForPredicateCells(Func<string, bool> predicate, int shift)
        {
            var cellsToChange = _cells.Keys.Where(cellId => predicate(GetRowId(cellId)));
            foreach (string cellId in cellsToChange)
            {
                ICell cell = _cells[cellId];
                _cells.Remove(cellId);
                _cells[GetCellIdWhithShiftedRow(cellId, shift)] = cell;
            }
        }

        private void ShiftRowIdForPredicateReferences(Func<string, bool> predicate, int shift)
        {
            foreach (ICell cell in _cells.Values)
            {
                if (cell.Expression == null)
                    continue;

                var cellsToChange = cell.Expression.ReferencedCells.Where(cellId => predicate(GetRowId(cellId)));
                foreach (string referencedCellId in cellsToChange)
                {
                    cell.Expression.RenameReference(referencedCellId, GetCellIdWhithShiftedRow(referencedCellId, shift));
                }
            }
        }

        private void ShiftColumnIdForPredicate(Func<string, bool> predicate, int shift)
        {
            ShiftColumnIdForPredicateCells(predicate, shift);
            ShiftColumnIdForPredicateReferences(predicate, shift);
        }

        private void ShiftColumnIdForPredicateCells(Func<string, bool> predicate, int shift)
        {
            var cellsToChange = _cells.Keys.Where(cellId => predicate(GetColumnId(cellId)));
            foreach (string cellId in cellsToChange)
            {
                ICell cell = _cells[cellId];
                _cells.Remove(cellId);
                _cells[GetCellIdWhithShiftedColumn(cellId, shift)] = cell;
            }
        }

        private void ShiftColumnIdForPredicateReferences(Func<string, bool> predicate, int shift)
        {
            foreach (ICell cell in _cells.Values)
            {
                if (cell.Expression == null)
                    continue;

                var cellsToChange = cell.Expression.ReferencedCells.Where(cellId => predicate(GetColumnId(cellId)));
                foreach (string referencedCellId in cellsToChange)
                {
                    cell.Expression.RenameReference(referencedCellId, GetCellIdWhithShiftedColumn(referencedCellId, shift));
                }
            }
        }

        private string GetCellIdWhithShiftedRow(string cellId, int shift)
        {
            string rowId = GetRowId(cellId);
            int rowIndex = GetRowIndex(rowId);
            return GetColumnId(cellId) + GetRowId(rowIndex + shift);
        }

        private string GetCellIdWhithShiftedColumn(string cellId, int shift)
        {
            string columnId = GetColumnId(cellId);
            int columnIndex = GetColumnIndex(columnId);
            return GetColumnId(columnIndex + shift) + GetRowId(cellId);
        }
    }
}
