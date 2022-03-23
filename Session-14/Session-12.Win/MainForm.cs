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

        
    }
}