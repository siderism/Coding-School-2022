using Final.EF.Context;
using Final.EF.Repos;
using Final.Handlers;
using Final.Model;

namespace Final.Win
{
    public partial class HomeF : Form
    {
        private HttpClient _httpClient;
        private TransactionHandler _handler;

        public HomeF()
        {
            InitializeComponent();
            _handler = new TransactionHandler();
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7126/");
        }

        private void customersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmCustomerList = new CustomersF(_httpClient);
            frmCustomerList.ShowDialog();
        }

        private void itemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmCustomerList = new ItemsF(_httpClient);
            frmCustomerList.ShowDialog();
        }

        private void transactionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmCustomerList = new TransactionsF(_httpClient, _handler);
            frmCustomerList.ShowDialog();
        }
    }
}