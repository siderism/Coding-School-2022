using Final.Handlers;
using Final.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final.Win
{
    public partial class TransactionsF : Form
    {
        private TransactionEditViewModel? _selectedTransaction;
        private List<TransactionListViewModel> _transactionList;
        private HttpClient _client;
        private TransactionHandler _handler;
        public TransactionsF(HttpClient httpClient, TransactionHandler handler)
        {
            InitializeComponent();
            _client = httpClient;
            _handler = handler;
        }

        private async void TransactionsF_Load(object sender, EventArgs e)
        {
            await RefreshTransactionList();

            grvTransactions.ReadOnly = true;
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            var carNumber = new CardNumberF(_client, _handler);
            carNumber.ShowDialog();
            await RefreshTransactionList();
        }

        private async void btnEdit_Click(object sender, EventArgs e)
        {
            if (grvTransactions.SelectedRows.Count != 1)
                return;

            var tmpTransaction = (TransactionListViewModel)grvTransactions.SelectedRows[index: 0].DataBoundItem;
            _selectedTransaction = await _client.GetFromJsonAsync<TransactionEditViewModel>($"transaction/{tmpTransaction.Id}");
            var frmTransactionEdit = new TransactionEditF(_client, _selectedTransaction, _handler);
            frmTransactionEdit.ShowDialog();
            await RefreshTransactionList();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var tmpTransaction = (TransactionListViewModel)grvTransactions.SelectedRows[index: 0].DataBoundItem;
            _client.DeleteAsync($"transaction/{tmpTransaction.Id}");
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await RefreshTransactionList();
        }

        private async Task LoadItemsFromServer()
        {
            _transactionList = await _client.GetFromJsonAsync<List<TransactionListViewModel>>("transaction");
        }

        private async Task RefreshTransactionList()
        {
            grvTransactions.DataSource = null;

            await LoadItemsFromServer();
            grvTransactions.DataSource = _transactionList;

            grvTransactions.Update();
            grvTransactions.Refresh();
            grvTransactions.Columns["Id"].Visible = false;
            SetCollumsGridView();
        }

        private void SetCollumsGridView()
        {
            grvTransactions.Columns["Date"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grvTransactions.Columns["Date"].DefaultCellStyle.Format = "MM/dd/yyyy HH:mm:ss";

            grvTransactions.Columns["CustomerFullName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grvTransactions.Columns["CustomerFullName"].HeaderText = "Customer";

            grvTransactions.Columns["EmployeeFullName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grvTransactions.Columns["EmployeeFullName"].HeaderText = "Employee";

            grvTransactions.Columns["PayMentMethod"].HeaderText = "Payment-Method";
            grvTransactions.Columns["PayMentMethod"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            grvTransactions.Columns["TotalValue"].HeaderText = "Total Value";
            grvTransactions.Columns["TotalValue"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }
    }
}
