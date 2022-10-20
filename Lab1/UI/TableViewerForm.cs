using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Lab1.Models.Parsers.Exceptions;
using Lab1.Models.Expressions.Exceptions;
using Lab1.Models.Expressions;

namespace Lab1
{
    public partial class TableViewerForm : Form
    {
        private readonly Controller _controller;

        public TableViewerForm(Controller controller)
        {
            InitializeComponent();
            SetupHandlers();

            _controller = controller;
        }


        #region Additional handlers setup
        private void SetupHandlers() 
        {
            tableDataGridView.CellEndEdit += tableDataGridView_CellEndEdit;
        }

        private void tableDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e) 
        {
            DataGridViewCell cell = tableDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];
            if (cell.Value != null)
            {
                string expression = GetExpression(cell);
                if (expression.Length == 0)
                    return;
                cell.ErrorText = UpdateExpressionInCellAndGetErrorText(GetCellID(cell), expression);
            }
        }

        private static string GetCellID(DataGridViewCell cell)
        {
            return cell.OwningColumn.HeaderCell.Value.ToString() + cell.OwningRow.HeaderCell.Value.ToString();
        }

        private static string GetExpression(DataGridViewCell cell)
        {
            return cell.Value.ToString().Trim();
        }

        private string UpdateExpressionInCellAndGetErrorText(string cellID, string expression)
        {
            try
            {
                _controller.UpdateExpressionInCell(cellID, expression);
                return String.Empty;
            }
            catch (ParserException)
            {
                return "Syntax error";
            }
            catch (ZeroDevisionInExpressionException e)
            {
                return $"Ділення на 0 у виразі: {GetMarkedSubstring(e)}";
            }
            catch (ReferencedInvalidExpressionException e)
            {
                return $"Звертання до невірного виразу у {e.CellId}";
            }
            catch (ModForNonintegersException e)
            {
                return $"Застосування операції мод до нецілочисленного операнда: {GetMarkedSubstring(e)}";
            }
            catch (ExpressionCalculationException e)
            {
                return $"Невизначена помилка під час обчислення: {GetMarkedSubstring(e)}";
            }
        }

        private static string GetMarkedSubstring(ExpressionCalculationException e)
        {
            return e.Expression.ToString().Substring(e.StartPos, e.EndPos - e.StartPos);
        }
        #endregion

        #region tableDataGridView setup

        private void TableViewerForm_Load(object sender, EventArgs e)
        {
            SetupTableDataGridView();
        }

        private void SetupTableDataGridView()
        {
            SetupTableColumns();
            SetupTableRows();
        }

        /// <summary> 
        /// Method <c>SetupTableColumns</c> setups columns layout of <c>tableDatagridView</c>.
        /// </summary>
        private void SetupTableColumns()
        {
            for (int i = 0; i < _controller.GetColumnsNumber(); i++)
            {
                string headerName = ColumnNameFromIndex(i);
                string columnName = $"column{headerName}";
                tableDataGridView.Columns.Add(columnName, headerName);
                tableDataGridView.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable; 
            }
        }

        /// <summary> 
        /// Method <c>ColumnNameFromIndex</c> gets columns's name from itss index (e.g. "AB" for index 27).
        /// Indexes start from 0.
        /// </summary>
        static private string ColumnNameFromIndex(int index)
        {
            const int alphabetSize = 26;

            StringBuilder name = new();
            name.Append((char)('A' + index % alphabetSize));
            index /= alphabetSize;
            while (index > 0)
            {
                name.Append((char) ('A' + index % alphabetSize - 1));
                index /= alphabetSize;
            }

            return new string(name.ToString().Reverse().ToArray());
        }

        private void SetupTableRows()
        {
            tableDataGridView.Rows.Add(_controller.GetRowsNumber());

            foreach(DataGridViewRow row in tableDataGridView.Rows)
            {
                row.HeaderCell.Value = (row.Index + 1).ToString();
            }    
        }

        #endregion
    }
}
