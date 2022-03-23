using Session_14.EF.Repos;
using Session_14.Model;

namespace Session_12.Win
{
    public partial class MainForm : Form
    {
        private readonly IEntityRepo<Transaction> _transactionRepo;
        private List<Transaction> _transactions = new List<Transaction>();
        public MainForm(IEntityRepo<Transaction> transactionRepo)
        {
            InitializeComponent();
            _transactionRepo = transactionRepo;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RefreshTransactions();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //RefreshTransactions();
        }

        private void RefreshTransactions()
        {
            _transactions = _transactionRepo.GetAll();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = _transactions;
            dataGridView1.Refresh();
            dataGridView1.Update();
        }
    }
}