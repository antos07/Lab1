namespace Lab1.UI
{
    partial class MainMenu
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.createTableButton = new System.Windows.Forms.Button();
            this.openTableButton = new System.Windows.Forms.Button();
            this.openTableDialog = new System.Windows.Forms.OpenFileDialog();
            this.showHelpButton = new System.Windows.Forms.Button();
            this.showProgramInfoButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // createTableButton
            // 
            this.createTableButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.createTableButton.Location = new System.Drawing.Point(436, 313);
            this.createTableButton.Name = "createTableButton";
            this.createTableButton.Size = new System.Drawing.Size(408, 112);
            this.createTableButton.TabIndex = 1;
            this.createTableButton.Text = "Створити таблицю";
            this.createTableButton.UseVisualStyleBackColor = true;
            this.createTableButton.Click += new System.EventHandler(this.createTableButton_Click);
            // 
            // openTableButton
            // 
            this.openTableButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.openTableButton.Location = new System.Drawing.Point(436, 177);
            this.openTableButton.Name = "openTableButton";
            this.openTableButton.Size = new System.Drawing.Size(408, 112);
            this.openTableButton.TabIndex = 0;
            this.openTableButton.Text = "Відкрити таблицю";
            this.openTableButton.UseVisualStyleBackColor = true;
            this.openTableButton.Click += new System.EventHandler(this.openTableButton_Click);
            // 
            // openTableDialog
            // 
            this.openTableDialog.Filter = "JSON-файли (*.json)|*.json|Усі файли (*.*)|*.*";
            this.openTableDialog.Title = "Відкрити таблицю";
            // 
            // showHelpButton
            // 
            this.showHelpButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.showHelpButton.Location = new System.Drawing.Point(436, 449);
            this.showHelpButton.Name = "showHelpButton";
            this.showHelpButton.Size = new System.Drawing.Size(408, 112);
            this.showHelpButton.TabIndex = 2;
            this.showHelpButton.Text = "Допомога\r\n";
            this.showHelpButton.UseVisualStyleBackColor = true;
            this.showHelpButton.Click += new System.EventHandler(this.showHelpButton_Click);
            // 
            // showProgramInfoButton
            // 
            this.showProgramInfoButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.showProgramInfoButton.Location = new System.Drawing.Point(436, 585);
            this.showProgramInfoButton.Name = "showProgramInfoButton";
            this.showProgramInfoButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.showProgramInfoButton.Size = new System.Drawing.Size(408, 112);
            this.showProgramInfoButton.TabIndex = 3;
            this.showProgramInfoButton.Text = "Про програму";
            this.showProgramInfoButton.UseVisualStyleBackColor = true;
            this.showProgramInfoButton.Click += new System.EventHandler(this.showProgramInfoButton_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(17F, 41F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 874);
            this.Controls.Add(this.createTableButton);
            this.Controls.Add(this.showHelpButton);
            this.Controls.Add(this.openTableButton);
            this.Controls.Add(this.showProgramInfoButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.Name = "MainMenu";
            this.Text = "Електронні таблиці";
            this.ResumeLayout(false);

        }

        #endregion

        private Button createTableButton;
        private Button openTableButton;
        private OpenFileDialog openTableDialog;
        private Button showHelpButton;
        private Button showProgramInfoButton;
    }
}