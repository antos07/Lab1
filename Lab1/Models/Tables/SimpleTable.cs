using Antlr4.Runtime.Dfa;
using Lab1.Models.Cells;
using Lab1.Models.Tables.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static Antlr4.Runtime.Atn.SemanticContext;

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

        public ICell GetCell(string cellId)
        {
            CleanIfNeeded();

            if (!IsValidCellId(cellId))
                throw new UnexistingCellException(cellId);

            if (!_cells.ContainsKey(cellId))
                _cells.Add(cellId, new SimpleCell(this));
            return _cells[cellId];
        }

        private bool IsValidCellId(string cellId)
        {
            if (!Regex.IsMatch(cellId, @"^\w+\d+$"))
                return false;
            int columnIndex = GetColumnIndex(GetColumnId(cellId));
            int rowIndex = GetRowIndex(GetRowId(cellId));

            return rowIndex > 0 && rowIndex <= RowsNumber && columnIndex < ColumnsNumber;
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
            ShiftRowIdForPredicateCells(rowId => GetRowIndex(rowId) > rowIndex, -1);
            ShiftRowIdForPredicateReferences(rowId => GetRowIndex(rowId) >= rowIndex, -1);
            RowsNumber--;
        }

        public void DeleteColumn(string columnId)
        {
            RemoveCellsWithColumnId(columnId);
            int columnIndex = GetColumnIndex(columnId);
            ColumnsNumber--;
            ShiftColumnIdForPredicateCells(columnId => GetColumnIndex(columnId) > columnIndex, -1);
            ShiftColumnIdForPredicateReferences(columnId => GetColumnIndex(columnId) >= columnIndex, -1);
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
            if (columnIndex < 0)
                return "#";

            const int alphabetSize = 26;

            StringBuilder name = new();
            name.Append((char)('A' + columnIndex % alphabetSize));
            columnIndex /= alphabetSize;
            while (columnIndex > 0)
            {
                name.Append((char)('A' + columnIndex % alphabetSize - 1));
                columnIndex /= alphabetSize;
            }

            return new string(name.ToString().Reverse().ToArray());
        }

        private int GetRowIndex(string rowId) => Convert.ToInt32(rowId);

        private int GetColumnIndex(string columnId)
        {
            int index = 0;
            foreach (char c in columnId)
            {
                index *= 26;
                index += c - 'A';
            }
            return index;
        }

        private void ShiftRowIdForPredicateCells(Func<string, bool> predicate, int shift)
        {
            var cellsToChange = _cells.Keys.Where(cellId => predicate(GetRowId(cellId))).ToList();
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
                Dictionary<string, string> renames = new();
                foreach (string referencedCellId in cellsToChange)
                {
                    renames[referencedCellId] = GetCellIdWhithShiftedRow(referencedCellId, shift);
                }
                cell.Expression.RenameReferences(renames);
            }
        }

        private void ShiftColumnIdForPredicateCells(Func<string, bool> predicate, int shift)
        {
            var cellsToChange = _cells.Keys.Where(cellId => predicate(GetColumnId(cellId))).ToList();
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
                Dictionary<string, string> renames = new();
                foreach (string referencedCellId in cellsToChange)
                {
                    renames[referencedCellId] = GetCellIdWhithShiftedColumn(referencedCellId, shift);
                }
                cell.Expression.RenameReferences(renames);
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

        public void InsertRow(string desiredRowId)
        {
            throw new NotImplementedException();
        }

        public void InsertColumn(string desiredColumnId)
        {
            throw new NotImplementedException();
        }
    }
}
