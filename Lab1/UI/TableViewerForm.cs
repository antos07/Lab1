using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Lab1.Models.Parsers.Exceptions;
using Lab1.Models.Expressions.Exceptions;
using Lab1.Models.Expressions;
using System.CodeDom;
using ExtendedNumerics;
using Lab1.Models.Tables.Exceptions;

namespace Lab1
{
    public partial class TableViewerForm : Form
    {
        private readonly Controller _controller;
        private bool _skipExpressionSave = false;

        public TableViewerForm(Controller controller)
        {
            InitializeComponent();
            SetupHandlers();

            tableDataGridView.EnableHeadersVisualStyles = false;
            _controller = controller;
        }

        #region Handlers
        private void SetupHandlers()
        {
            tableDataGridView.CellBeginEdit += tableDataGridView_CellBeginEdit;
            tableDataGridView.CellEndEdit += tableDataGridView_CellEndEdit;
            FormClosing += TableViewerForm_FormClosing;
        }

        private void TableViewerForm_Load(object sender, EventArgs e)
        {
            ReloadTable();
        }

        private void TableViewerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_controller.IsTableOpened())
                return;

            switch (MessageBox.Show("Хочете зберегти у файл?", "Електронні таблиці", MessageBoxButtons.YesNoCancel))
            {
                case DialogResult.Yes:
                    if (!SaveToFile())
                        e.Cancel = true;
                    break;
                case DialogResult.Cancel:
                    e.Cancel = true;
                    break;
                case DialogResult.No:
                default:
                    break;
            }
        }

        private void tableDataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            DataGridViewCell cell = tableDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];
            cell.Style.BackColor = Color.AliceBlue;
            cell.OwningRow.HeaderCell.Style.BackColor = Color.LightYellow;
            cell.OwningColumn.HeaderCell.Style.BackColor = Color.LightYellow;

            if (!onlyExpressionsModeToolStripMenuItem.Checked)
            {
                DisplayCellExpression(cell);
            }
        }

        private void tableDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell cell = tableDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];

            cell.Style.BackColor = SystemColors.Window;
            cell.OwningRow.HeaderCell.Style.BackColor = SystemColors.Control;
            cell.OwningColumn.HeaderCell.Style.BackColor = SystemColors.Control;

            if (_skipExpressionSave)
                return;
            if (cell.Value == null)
                cell.Value = string.Empty;
            string newExpression = cell.Value.ToString();
            cell.ErrorText = UpdateExpressionInCellAndGetErrorText(GetCellID(cell), newExpression);

            if (!onlyExpressionsModeToolStripMenuItem.Checked)
            {
                DisplayCellExpressionValue(cell);
            }
        }

        private void onlyExpressionsModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (onlyExpressionsModeToolStripMenuItem.Checked)
            {
                updateAllCellsToolStripMenuItem.Enabled = false;
                DisplayAllExpressions();
            }
            else
            {
                updateAllCellsToolStripMenuItem.Enabled = true;
                DisplayAllExpressionValues();
            }
        }

        private void updateAllCellsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplayAllExpressionValues();
        }

        private void saveTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveToFile();
        }

        private void openTabelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Хочете зберегти у файл?", "Електронні таблиці", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                SaveToFile();
            }
            _controller.CloseTable();
            if (openFileDialog.ShowDialog(this) == DialogResult.OK && _controller.OpenTable(openFileDialog.FileName))
            {
                ReloadTable();
            }
            else
            {
                MessageBox.Show("Невдалося відкрити файл");
                Close();
            }
        }

        private void createNewTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Хочете зберегти у файл?", "Електронні таблиці", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                SaveToFile();
            }
            _controller.CloseTable();
            _controller.CreteTable();
            Close();
            ReloadTable();
        }

        private void deleteCurrentRowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewCell cell = tableDataGridView.CurrentCell;
            int rowId = cell.RowIndex;
            int columnId = cell.ColumnIndex;
            
            _skipExpressionSave = true;
            bool isChecked = onlyExpressionsModeToolStripMenuItem.Checked;
            _controller.DeleteRow(cell.OwningRow.HeaderCell.Value.ToString());
            ReloadTable();
            onlyExpressionsModeToolStripMenuItem.Checked = isChecked;
            _skipExpressionSave = false;

            tableDataGridView.CurrentCell = tableDataGridView.Rows[rowId].Cells[columnId];
        }

        private void deleteCurrentColumnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewCell cell = tableDataGridView.CurrentCell;
            int rowId = cell.RowIndex;
            int columnId = cell.ColumnIndex;

            _skipExpressionSave = true;
            bool isChecked = onlyExpressionsModeToolStripMenuItem.Checked;
            _controller.DeleteColumn(cell.OwningColumn.HeaderCell.Value.ToString());
            ReloadTable();
            onlyExpressionsModeToolStripMenuItem.Checked = isChecked;
            _skipExpressionSave = false;

            tableDataGridView.CurrentCell = tableDataGridView.Rows[rowId].Cells[columnId];
        }

        private void addRowBeforeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewCell cell = tableDataGridView.CurrentCell;
            int rowId = cell.RowIndex;
            int columnId = cell.ColumnIndex;

            _skipExpressionSave = true;
            bool isChecked = onlyExpressionsModeToolStripMenuItem.Checked;
            _controller.InsertRow(cell.OwningRow.HeaderCell.Value.ToString());
            ReloadTable();
            onlyExpressionsModeToolStripMenuItem.Checked = isChecked;
            _skipExpressionSave = false;

            tableDataGridView.CurrentCell = tableDataGridView.Rows[rowId + 1].Cells[columnId];
        }

        private void addRowBelowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewCell cell = tableDataGridView.CurrentCell;
            int rowId = cell.RowIndex;
            int columnId = cell.ColumnIndex;

            _skipExpressionSave = true;
            bool isChecked = onlyExpressionsModeToolStripMenuItem.Checked;
            _controller.InsertRow((rowId + 2).ToString());
            ReloadTable();
            onlyExpressionsModeToolStripMenuItem.Checked = isChecked;
            _skipExpressionSave = false;

            tableDataGridView.CurrentCell = tableDataGridView.Rows[rowId].Cells[columnId];
        }

        private void addColumnLefyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewCell cell = tableDataGridView.CurrentCell;
            int rowId = cell.RowIndex;
            int columnId = cell.ColumnIndex;

            _skipExpressionSave = true;
            bool isChecked = onlyExpressionsModeToolStripMenuItem.Checked;
            _controller.InsertColumn(cell.OwningColumn.HeaderCell.Value.ToString());
            ReloadTable();
            onlyExpressionsModeToolStripMenuItem.Checked = isChecked;
            _skipExpressionSave = false;

            tableDataGridView.CurrentCell = tableDataGridView.Rows[rowId].Cells[columnId + 1];
        }

        private void addColumnRightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewCell cell = tableDataGridView.CurrentCell;
            int rowId = cell.RowIndex;
            int columnId = cell.ColumnIndex;

            _skipExpressionSave = true;
            bool isChecked = onlyExpressionsModeToolStripMenuItem.Checked;
            _controller.InsertColumn(ColumnNameFromIndex(columnId + 1));
            ReloadTable();
            onlyExpressionsModeToolStripMenuItem.Checked = isChecked;
            _skipExpressionSave = false;

            tableDataGridView.CurrentCell = tableDataGridView.Rows[rowId].Cells[columnId];
        }

        #endregion

        #region tableDataGridView setup

        void ReloadTable()
        {
            Enabled = false;
            ClearTable();
            SetupTableDataGridView();
            Enabled = true;

            if (onlyExpressionsModeToolStripMenuItem.Checked)
                DisplayAllExpressions();
            else
                DisplayAllExpressionValues();
            UpdateAllErrorMessages();
        }

        void ClearTable()
        {
            updateAllCellsToolStripMenuItem.Checked = false;
            tableDataGridView.Rows.Clear();
            tableDataGridView.Columns.Clear();
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

        private void SetupTableRows()
        {
            tableDataGridView.Rows.Add(_controller.GetRowsNumber());

            foreach (DataGridViewRow row in tableDataGridView.Rows)
            {
                row.HeaderCell.Value = (row.Index + 1).ToString();
            }
        }

        #endregion

        #region Utils

        private static string GetCellID(DataGridViewCell cell)
        {
            return cell.OwningColumn.HeaderCell.Value.ToString() + cell.OwningRow.HeaderCell.Value.ToString();
        }

        void DisplayCellExpression(DataGridViewCell cell)
        {
            if (cell.IsInEditMode)
                return;

            string cellId = GetCellID(cell);
            cell.Value = _controller.GetCellExpression(cellId);
            try
            {
                _controller.GetCellValue(cellId);
                cell.ErrorText = String.Empty;
            }
            catch (InvalidExpressionException)
            { }
            catch (Exception e)
            {
                cell.ErrorText = ErrorTextForException(e);
            }
        }

        private void DisplayCellExpressionValue(DataGridViewCell cell)
        {
            if (cell.IsInEditMode)
                return;

            string cellId = GetCellID(cell);
            try
            {
                object? cellValue = _controller.GetCellValue(cellId);
                if (cellValue is BigRational && cellValue != null)
                {
                    BigRational t = (BigRational)cellValue;
                    cellValue = (t.WholePart == 0 ? (decimal)t.FractionalPart : (decimal)t);
                }
                cell.Value = _controller.GetCellExpression(cellId) != String.Empty ? cellValue.ToString() : String.Empty;
                cell.ErrorText = String.Empty;
            }
            catch (InvalidExpressionException)
            {
                cell.Value = "ERROR";
            }
            catch (Exception e)
            {
                cell.Value = "ERROR";
                cell.ErrorText = ErrorTextForException(e);
            }
        }

        private void DisplayAllExpressions()
        {
            foreach (DataGridViewRow row in tableDataGridView.Rows)
            {
                foreach (DataGridViewTextBoxCell cell in row.Cells)
                {
                    DisplayCellExpression(cell);
                }
            }
        }

        private void DisplayAllExpressionValues()
        {
            foreach (DataGridViewRow row in tableDataGridView.Rows)
            {
                foreach (DataGridViewTextBoxCell cell in row.Cells)
                {
                    DisplayCellExpressionValue(cell);
                }
            }
        }

        private void UpdateAllErrorMessages()
        {
            foreach (DataGridViewRow row in tableDataGridView.Rows)
            {
                foreach (DataGridViewTextBoxCell cell in row.Cells)
                {
                    UpdateErrorMessage(cell);
                }
            }
        }

        private void UpdateErrorMessage(DataGridViewTextBoxCell cell)
        {
            string cellId = GetCellID(cell);
            string expression = _controller.GetCellExpression(cellId);
            if (expression == string.Empty)
                return;

            cell.ErrorText = UpdateExpressionInCellAndGetErrorText(cellId, expression);
        }

        private string ErrorTextForException(Exception exception)
        {
            try
            {
                throw exception;
            }
            catch (ParserException e)
            {
                return "Syntax error: " + e.Message;
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
            catch (InfiniteRecursionException)
            {
                return $"У виразі присутня нескінченна рекурсія";
            }
            catch (UnexistingCellException e)
            {
                return $"Посилання на неіснуючу клітинку '{e.CellId}'";
            }
            catch (WrongTypeException e)
            {
                string message;
                if (e.ExpectedType == typeof(bool))
                    message = "Очікується логічний вираз замість ";
                else 
                    message = "Очікується арефмітичний вираз замість ";
                return message + GetMarkedSubstring(e);
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

        private string UpdateExpressionInCellAndGetErrorText(string cellID, string expression)
        {
            try
            {
                _controller.UpdateExpressionInCell(cellID, expression);
                return String.Empty;
            }
            catch (Exception e)
            {
                return ErrorTextForException(e);
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
                name.Append((char)('A' + index % alphabetSize - 1));
                index /= alphabetSize;
            }

            return new string(name.ToString().Reverse().ToArray());
        }

        bool SaveToFile()
        {
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string fileName = saveFileDialog.FileName;
                if (!_controller.SaveTable(fileName))
                {
                    MessageBox.Show("Не вдалося збрегти файл");
                    return false;
                }
                return true;
            }
            return false;
        }

        #endregion
    }
}
