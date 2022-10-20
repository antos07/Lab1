namespace Lab1.UI
{
    public partial class MainMenu : Form
    {
        private readonly Controller _controller;

        public MainMenu(Controller controller)
        {
            InitializeComponent();

            _controller = controller;
        }

        private void createTableButton_Click(object sender, EventArgs e)
        {
            _controller.CreteTable();
            OpenTable();
        }

        private void openTableButton_Click(object sender, EventArgs e)
        {
            if (openTableDialog.ShowDialog(this) == DialogResult.OK)
            {
                _controller.OpenTable(openTableDialog.FileName);
                OpenTable();
            }
        }

        private void OpenTable()
        {
            using TableViewerForm tableViewerForm = new(_controller);
            Hide();

            tableViewerForm.ShowDialog();
            Close();
        }

        private void showProgramInfoButton_Click(object sender, EventArgs e)
        {
            using AboutBox aboutBox = new();
            aboutBox.ShowDialog(this);
        }

        private void showHelpButton_Click(object sender, EventArgs e)
        {
            using HelpForm helpForm = new();
            helpForm.ShowDialog(this);
        }
    }
}