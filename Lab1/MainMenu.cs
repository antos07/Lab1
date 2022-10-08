namespace Lab1
{
    public partial class MainMenu : Form
    {
        private Controller _controller;

        public MainMenu(Controller controller)
        {
            InitializeComponent();

            _controller = controller;
        }

        private void createTableButton_Click(object sender, EventArgs e)
        {
            OpenTable();
        }

        private void openTableButton_Click(object sender, EventArgs e)
        {
            if (openTableDialog.ShowDialog() == DialogResult.OK)
            {
                OpenTable(openTableDialog.FileName);
            }
        }

        private void OpenTable(string? filename = null)
        {
            MessageBox.Show(filename);

            TableViewerForm tableViewerForm = new();
            this.Hide();

            tableViewerForm.ShowDialog();
            this.Close();
        }

        private void showProgramInfoButton_Click(object sender, EventArgs e)
        {
            using (AboutBox aboutBox = new())
                aboutBox.ShowDialog(this);
        }

        private void showHelpButton_Click(object sender, EventArgs e)
        {
            
        }
    }
}