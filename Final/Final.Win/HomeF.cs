using Final.EF.Context;
using Final.EF.Repos;
using Final.Handlers;
using Final.Model;
using Final.Shared.ViewModels;

namespace Final.Win
{
    public partial class HomeF : Form
    {
        private HttpClient _httpClient;
        private TransactionHandler _handler;
        private LoginViewModel _login;

        public HomeF(HttpClient httpClient, LoginViewModel login)
        {
            InitializeComponent();
            _handler = new TransactionHandler();
            _httpClient = httpClient;
            _login = login;
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