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
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TableDataGridView = new System.Windows.Forms.DataGridView();
            this.createNewTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openTabelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openHelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutProgramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TableViewerMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TableDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // TableViewerMenuStrip
            // 
            this.TableViewerMenuStrip.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.TableViewerMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuToolStripMenuItem,
            this.editToolStripMenuItem,
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
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(212, 45);
            this.editToolStripMenuItem.Text = "Редагування";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.релагуанняToolStripMenuItem_Click);
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
            // TableDataGridView
            // 
            this.TableDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TableDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableDataGridView.Location = new System.Drawing.Point(0, 49);
            this.TableDataGridView.Name = "TableDataGridView";
            this.TableDataGridView.RowHeadersWidth = 102;
            this.TableDataGridView.RowTemplate.Height = 49;
            this.TableDataGridView.Size = new System.Drawing.Size(1943, 1052);
            this.TableDataGridView.TabIndex = 1;
            // 
            // createNewTableToolStripMenuItem
            // 
            this.createNewTableToolStripMenuItem.Name = "createNewTableToolStripMenuItem";
            this.createNewTableToolStripMenuItem.Size = new System.Drawing.Size(448, 54);
            this.createNewTableToolStripMenuItem.Text = "Нова таблиця";
            // 
            // openTabelToolStripMenuItem
            // 
            this.openTabelToolStripMenuItem.Name = "openTabelToolStripMenuItem";
            this.openTabelToolStripMenuItem.Size = new System.Drawing.Size(448, 54);
            this.openTabelToolStripMenuItem.Text = "Відкрити таблицю";
            // 
            // saveTableToolStripMenuItem
            // 
            this.saveTableToolStripMenuItem.Name = "saveTableToolStripMenuItem";
            this.saveTableToolStripMenuItem.Size = new System.Drawing.Size(448, 54);
            this.saveTableToolStripMenuItem.Text = "Зберегти у файл";
            // 
            // openHelpToolStripMenuItem
            // 
            this.openHelpToolStripMenuItem.Name = "openHelpToolStripMenuItem";
            this.openHelpToolStripMenuItem.Size = new System.Drawing.Size(448, 54);
            this.openHelpToolStripMenuItem.Text = "Допомога";
            // 
            // aboutProgramToolStripMenuItem
            // 
            this.aboutProgramToolStripMenuItem.Name = "aboutProgramToolStripMenuItem";
            this.aboutProgramToolStripMenuItem.Size = new System.Drawing.Size(448, 54);
            this.aboutProgramToolStripMenuItem.Text = "О програмі";
            // 
            // TableViewerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(17F, 41F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1943, 1101);
            this.Controls.Add(this.TableDataGridView);
            this.Controls.Add(this.TableViewerMenuStrip);
            this.MainMenuStrip = this.TableViewerMenuStrip;
            this.Name = "TableViewerForm";
            this.Text = "Електронні таблиці";
            this.Load += new System.EventHandler(this.TableViewerForm_Load);
            this.TableViewerMenuStrip.ResumeLayout(false);
            this.TableViewerMenuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TableDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip TableViewerMenuStrip;
        private ToolStripMenuItem MenuToolStripMenuItem;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private DataGridView TableDataGridView;
        private ToolStripMenuItem createNewTableToolStripMenuItem;
        private ToolStripMenuItem openTabelToolStripMenuItem;
        private ToolStripMenuItem saveTableToolStripMenuItem;
        private ToolStripMenuItem openHelpToolStripMenuItem;
        private ToolStripMenuItem aboutProgramToolStripMenuItem;
    }
}