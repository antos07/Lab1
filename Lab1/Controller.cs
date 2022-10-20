using Lab1.Models.Cells;
using Lab1.Models.Expressions;
using ExpExceptions = Lab1.Models.Expressions.Exceptions;
using Lab1.Models.Parsers.Exceptions;
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

        /// <summary>
        /// Updates expression in cell. All exceptions are propagated to the View so it can display them correctly.
        /// </summary>
        /// <param name="cellID">Id of the cell</param>
        /// <param name="expression">New expression</param>
        /// <returns></returns>
        public void UpdateExpressionInCell(string cellID, string expression)
        {
            InsureTableOpened();

            ICell cell = _table.GetCell(cellID);
            try
            {
                cell.Expression = _parser.ParseExpression(expression);
            }
            catch (ParserException)
            {
                cell.Expression = new InvalidExpression(expression);
                throw;
            }

            // checking for runtime errors
            cell.GetValue();
        }

        public bool GetCellValue(string cell)
        {
            InsureTableOpened();
            return _table.GetCell(cell).GetValue();
        }

        public string GetCellExpression(string cell)
        {
            InsureTableOpened();
            IExpression? expression = _table.GetCell(cell).Expression;
            return expression == null ? String.Empty : expression.ToString();
        }

        private void InsureTableOpened()
        {
            if (_table == null)
                throw new ApplicationException();
        }
    }
}
