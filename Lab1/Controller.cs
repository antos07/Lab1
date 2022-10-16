using Lab1.Models.Cells;
using Lab1.Models.Expressions;
using Lab1.Models.Tables;
using Lab1.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.Design;

namespace Lab1
{
    public class Controller
    {
        private readonly IParser _parser;
        private SimpleTable? _table;

        public Controller(IParser parser)
        {
            _parser = parser;
        }

        public void CreteTable()
        { 
            _table = new SimpleTable();
        }

        public void OpenTable(string filename) 
        {
            _table = new SimpleTable();
        }

        public int GetColumnsNumber()
        {
            InsureTableOpened();
            return _table.ColumnsNamber;
        }

        public int GetRowsNumber()
        {
            return _table.RowsNamber;
        }

        public void UpdateExpressionInCell(string cellID, string? expression)
        {
            InsureTableOpened();

            ICell cell = _table.GetCell(cellID);
            cell.Expression = expression != null ? _parser.ParseExpression(expression) : new SimpleExpression(String.Empty);
        }

        public string GetCellValue(string cell)
        {
            InsureTableOpened();
            return _table.GetCell(cell).Value;
        }

        public string GetCellExpression(string cell)
        {
            InsureTableOpened();
            return _table.GetCell(cell).Expression.ToString();
        }

        private void InsureTableOpened()
        {
            if (_table == null)
                throw new ApplicationException();
        }
    }
}
