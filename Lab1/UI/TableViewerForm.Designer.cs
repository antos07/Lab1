namespace Lab1
{
    partial class TableViewerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TableViewerMenuStrip = new System.Windows.Forms.MenuStrip();
            this.MenuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createNewTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openTabelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteCurrentRowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteCurrentColumnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addRowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addRowBeforeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addRowBelowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addColumnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addColumnLefyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addColumnRightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.appearenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateAllCellsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.onlyExpressionsModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openHelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutProgramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableDataGridView = new System.Windows.Forms.DataGridView();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openTableDialog = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.TableViewerMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // TableViewerMenuStrip
            // 
            this.TableViewerMenuStrip.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.TableViewerMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuToolStripMenuItem,
            this.editToolStripMenuItem,
            this.appearenceToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.TableViewerMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.TableViewerMenuStrip.Name = "TableViewerMenuStrip";
            this.TableViewerMenuStrip.Size = new System.Drawing.Size(1943, 49);
            this.TableViewerMenuStrip.TabIndex = 0;
            this.TableViewerMenuStrip.Text = "menuStrip1";
            // 
            // MenuToolStripMenuItem
            // 
            this.MenuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createNewTableToolStripMenuItem,
            this.openTabelToolStripMenuItem,
            this.saveTableToolStripMenuItem});
            this.MenuToolStripMenuItem.Name = "MenuToolStripMenuItem";
            this.MenuToolStripMenuItem.Size = new System.Drawing.Size(126, 45);
            this.MenuToolStripMenuItem.Text = "Меню";
            // 
            // createNewTableToolStripMenuItem
            // 
            this.createNewTableToolStripMenuItem.Name = "createNewTableToolStripMenuItem";
            this.createNewTableToolStripMenuItem.Size = new System.Drawing.Size(430, 54);
            this.createNewTableToolStripMenuItem.Text = "Нова таблиця";
            this.createNewTableToolStripMenuItem.Click += new System.EventHandler(this.createNewTableToolStripMenuItem_Click);
            // 
            // openTabelToolStripMenuItem
            // 
            this.openTabelToolStripMenuItem.Name = "openTabelToolStripMenuItem";
            this.openTabelToolStripMenuItem.Size = new System.Drawing.Size(430, 54);
            this.openTabelToolStripMenuItem.Text = "Відкрити таблицю";
            this.openTabelToolStripMenuItem.Click += new System.EventHandler(this.openTabelToolStripMenuItem_Click);
            // 
            // saveTableToolStripMenuItem
            // 
            this.saveTableToolStripMenuItem.Name = "saveTableToolStripMenuItem";
            this.saveTableToolStripMenuItem.Size = new System.Drawing.Size(430, 54);
            this.saveTableToolStripMenuItem.Text = "Зберегти у файл";
            this.saveTableToolStripMenuItem.Click += new System.EventHandler(this.saveTableToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteCurrentRowToolStripMenuItem,
            this.deleteCurrentColumnToolStripMenuItem,
            this.addRowToolStripMenuItem,
            this.addColumnToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(212, 45);
            this.editToolStripMenuItem.Text = "Редагування";
            // 
            // deleteCurrentRowToolStripMenuItem
            // 
            this.deleteCurrentRowToolStripMenuItem.Name = "deleteCurrentRowToolStripMenuItem";
            this.deleteCurrentRowToolStripMenuItem.Size = new System.Drawing.Size(586, 54);
            this.deleteCurrentRowToolStripMenuItem.Text = "Видалити поточний рядок";
            this.deleteCurrentRowToolStripMenuItem.Click += new System.EventHandler(this.deleteCurrentRowToolStripMenuItem_Click);
            // 
            // deleteCurrentColumnToolStripMenuItem
            // 
            this.deleteCurrentColumnToolStripMenuItem.Name = "deleteCurrentColumnToolStripMenuItem";
            this.deleteCurrentColumnToolStripMenuItem.Size = new System.Drawing.Size(586, 54);
            this.deleteCurrentColumnToolStripMenuItem.Text = "Видалити поточний стовпчик";
            // 
            // addRowToolStripMenuItem
            // 
            this.addRowToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addRowBeforeToolStripMenuItem,
            this.addRowBelowToolStripMenuItem});
            this.addRowToolStripMenuItem.Name = "addRowToolStripMenuItem";
            this.addRowToolStripMenuItem.Size = new System.Drawing.Size(586, 54);
            this.addRowToolStripMenuItem.Text = "Додати рядок";
            // 
            // addRowBeforeToolStripMenuItem
            // 
            this.addRowBeforeToolStripMenuItem.Name = "addRowBeforeToolStripMenuItem";
            this.addRowBeforeToolStripMenuItem.Size = new System.Drawing.Size(480, 54);
            this.addRowBeforeToolStripMenuItem.Text = "Зверху від поточного";
            // 
            // addRowBelowToolStripMenuItem
            // 
            this.addRowBelowToolStripMenuItem.Name = "addRowBelowToolStripMenuItem";
            this.addRowBelowToolStripMenuItem.Size = new System.Drawing.Size(480, 54);
            this.addRowBelowToolStripMenuItem.Text = "Знизу від поточного";
            // 
            // addColumnToolStripMenuItem
            // 
            this.addColumnToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addColumnLefyToolStripMenuItem,
            this.addColumnRightToolStripMenuItem});
            this.addColumnToolStripMenuItem.Name = "addColumnToolStripMenuItem";
            this.addColumnToolStripMenuItem.Size = new System.Drawing.Size(586, 54);
            this.addColumnToolStripMenuItem.Text = "Додати стовпчик";
            // 
            // addColumnLefyToolStripMenuItem
            // 
            this.addColumnLefyToolStripMenuItem.Name = "addColumnLefyToolStripMenuItem";
            this.addColumnLefyToolStripMenuItem.Size = new System.Drawing.Size(485, 54);
            this.addColumnLefyToolStripMenuItem.Text = "Зліва від поточного";
            // 
            // addColumnRightToolStripMenuItem
            // 
            this.addColumnRightToolStripMenuItem.Name = "addColumnRightToolStripMenuItem";
            this.addColumnRightToolStripMenuItem.Size = new System.Drawing.Size(485, 54);
            this.addColumnRightToolStripMenuItem.Text = "Справа від поточного";
            // 
            // appearenceToolStripMenuItem
            // 
            this.appearenceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updateAllCellsToolStripMenuItem,
            this.onlyExpressionsModeToolStripMenuItem});
            this.appearenceToolStripMenuItem.Name = "appearenceToolStripMenuItem";
            this.appearenceToolStripMenuItem.Size = new System.Drawing.Size(134, 45);
            this.appearenceToolStripMenuItem.Text = "Вигляд";
            // 
            // updateAllCellsToolStripMenuItem
            // 
            this.updateAllCellsToolStripMenuItem.Name = "updateAllCellsToolStripMenuItem";
            this.updateAllCellsToolStripMenuItem.Size = new System.Drawing.Size(506, 54);
            this.updateAllCellsToolStripMenuItem.Text = "Оновити всі результати";
            this.updateAllCellsToolStripMenuItem.Click += new System.EventHandler(this.updateAllCellsToolStripMenuItem_Click);
            // 
            // onlyExpressionsModeToolStripMenuItem
            // 
            this.onlyExpressionsModeToolStripMenuItem.CheckOnClick = true;
            this.onlyExpressionsModeToolStripMenuItem.Name = "onlyExpressionsModeToolStripMenuItem";
            this.onlyExpressionsModeToolStripMenuItem.Size = new System.Drawing.Size(506, 54);
            this.onlyExpressionsModeToolStripMenuItem.Text = "Тільки вирази";
            this.onlyExpressionsModeToolStripMenuItem.Click += new System.EventHandler(this.onlyExpressionsModeToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openHelpToolStripMenuItem,
            this.aboutProgramToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(150, 45);
            this.helpToolStripMenuItem.Text = "Довідка";
            // 
            // openHelpToolStripMenuItem
            // 
            this.openHelpToolStripMenuItem.Name = "openHelpToolStripMenuItem";
            this.openHelpToolStripMenuItem.Size = new System.Drawing.Size(382, 54);
            this.openHelpToolStripMenuItem.Text = "Допомога";
            // 
            // aboutProgramToolStripMenuItem
            // 
            this.aboutProgramToolStripMenuItem.Name = "aboutProgramToolStripMenuItem";
            this.aboutProgramToolStripMenuItem.Size = new System.Drawing.Size(382, 54);
            this.aboutProgramToolStripMenuItem.Text = "Про програму";
            // 
            // tableDataGridView
            // 
            this.tableDataGridView.AllowUserToAddRows = false;
            this.tableDataGridView.AllowUserToDeleteRows = false;
            this.tableDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.tableDataGridView.Location = new System.Drawing.Point(0, 49);
            this.tableDataGridView.MultiSelect = false;
            this.tableDataGridView.Name = "tableDataGridView";
            this.tableDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.tableDataGridView.RowTemplate.Height = 49;
            this.tableDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.tableDataGridView.ShowEditingIcon = false;
            this.tableDataGridView.Size = new System.Drawing.Size(1943, 1052);
            this.tableDataGridView.TabIndex = 1;
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "json";
            this.saveFileDialog.Filter = "JSON-файли (*.json)|*.json|Усі файли (*.*)|*.*";
            // 
            // openTableDialog
            // 
            this.openTableDialog.Filter = "JSON-файли (*.json)|*.json|Усі файли (*.*)|*.*";
            this.openTableDialog.Title = "Відкрити таблицю";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "JSON-файли (*.json)|*.json|Усі файли (*.*)|*.*";
            this.openFileDialog1.Title = "Відкрити таблицю";
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "JSON-файли (*.json)|*.json|Усі файли (*.*)|*.*";
            // 
            // TableViewerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(17F, 41F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1943, 1101);
            this.Controls.Add(this.tableDataGridView);
            this.Controls.Add(this.TableViewerMenuStrip);
            this.MainMenuStrip = this.TableViewerMenuStrip;
            this.Name = "TableViewerForm";
            this.Text = "Електронні таблиці";
            this.Load += new System.EventHandler(this.TableViewerForm_Load);
            this.TableViewerMenuStrip.ResumeLayout(false);
            this.TableViewerMenuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip TableViewerMenuStrip;
        private ToolStripMenuItem MenuToolStripMenuItem;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private DataGridView tableDataGridView;
        private ToolStripMenuItem createNewTableToolStripMenuItem;
        private ToolStripMenuItem openTabelToolStripMenuItem;
        private ToolStripMenuItem saveTableToolStripMenuItem;
        private ToolStripMenuItem openHelpToolStripMenuItem;
        private ToolStripMenuItem aboutProgramToolStripMenuItem;
        private ToolStripMenuItem appearenceToolStripMenuItem;
        private ToolStripMenuItem updateAllCellsToolStripMenuItem;
        private ToolStripMenuItem onlyExpressionsModeToolStripMenuItem;
        private SaveFileDialog saveFileDialog;
        private OpenFileDialog openTableDialog;
        private OpenFileDialog openFileDialog1;
        private OpenFileDialog openFileDialog;
        private ToolStripMenuItem deleteCurrentRowToolStripMenuItem;
        private ToolStripMenuItem deleteCurrentColumnToolStripMenuItem;
        private ToolStripMenuItem addRowToolStripMenuItem;
        private ToolStripMenuItem addRowBeforeToolStripMenuItem;
        private ToolStripMenuItem addRowBelowToolStripMenuItem;
        private ToolStripMenuItem addColumnToolStripMenuItem;
        private ToolStripMenuItem addColumnLefyToolStripMenuItem;
        private ToolStripMenuItem addColumnRightToolStripMenuItem;
    }
}