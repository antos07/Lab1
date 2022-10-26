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
using Lab1.Utils;

namespace Lab1
{
    public class Controller
    {
        private readonly IParser _parser;
        private ITable? _table;

        public Controller(IParser parser)
        {
            _parser = parser;
        }

        public void CreteTable()
        {
            _table = new SimpleTable();
        }

        public bool OpenTable(string fileName)
        {
            try
            {
                string json = File.ReadAllText(fileName);
                _table = TableSerializer.Deserialize(json, _parser);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool SaveTable(string fileName)
        {
            InsureTableOpened();
            try
            {
                string json = TableSerializer.Serialize(_table);
                File.WriteAllText(fileName, json);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void CloseTable()
        {
            InsureTableOpened();
            _table = null;
        }

        public int GetColumnsNumber()
        {
            InsureTableOpened();
            return _table.ColumnsNumber;
        }

        public int GetRowsNumber()
        {
            return _table.RowsNumber;
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

        public object GetCellValue(string cell)
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
            if (IsTableOpened())
                throw new ApplicationException();
        }

        public bool IsTableOpened()
        {
            return _table == null;
        }

        public void DeleteRow(string rowID)
        {
            InsureTableOpened();

            _table.DeleteRow(rowID);
        }

        public void DeleteColumn(string columnID)
        {
            InsureTableOpened();

            _table.DeleteRow(columnID);
        }
    }
}
