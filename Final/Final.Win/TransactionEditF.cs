using Final.Handlers;
using Final.Model;
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
    public partial class TransactionEditF : Form
    {
        private HttpClient _client;
        private TransactionEditViewModel _transaction;
        private List<EmployeeViewModel> _currEmployees;
        private TransactionLineEditViewModel _selectedTransactionLine;
        private TransactionHandler _handler;
        public TransactionEditF(HttpClient httpClient, TransactionHandler handler)
        {
            InitializeComponent();
            _client = httpClient;
            _handler = handler;
        }

        public TransactionEditF(HttpClient httpClient, TransactionEditViewModel transaction, TransactionHandler handler) : this(httpClient, handler)
        {
            _transaction = transaction;
        }

        private async void TransactionEditF_Load(object sender, EventArgs e)
        {
            if (_transaction == null)
            {
                _transaction = new TransactionEditViewModel();
                _transaction.TransactionLineList = new();

            }
            await LoadFormServerEmployeeList();
            await LoadFromServerCustomer();

            bsTransaction.DataSource = _transaction;
            bsTransactionLine.DataSource = _transaction.TransactionLineList;

            SetReadOnlyFields();
            SetDataBindings();
            RefreshGridViewTransactionList();
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            var transacationLineF = new TransactionLineF(_client, _transaction, _handler);
            transacationLineF.ShowDialog();
            RefreshGridViewTransactionList();
        }

        private async void btnEdit_Click(object sender, EventArgs e)
        {
            if (grvTransaction.SelectedRows.Count != 1)
                return;

            //var tmpTransactionLine = (TransactionLineEdViewModel)grvTransactionLine.SelectedRows[index: 0].DataBoundItem;
            //var transacationLineF = new TransactionLineF(_client, _selectedTransactionLine);
            //transacationLineF.ShowDialog();
            RefreshGridViewTransactionList();
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (grvTransaction.SelectedRows.Count != 1)
                return;

            _selectedTransactionLine = (TransactionLineEditViewModel)grvTransaction.SelectedRows[index: 0].DataBoundItem;
            _transaction.TransactionLineList.Remove(_selectedTransactionLine);
            RefreshGridViewTransactionList();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCustomer.Text) ||
                string.IsNullOrWhiteSpace(comboBoxEmployee.Text) ||
                string.IsNullOrWhiteSpace(comboBoxPaymentMethod.Text))
                return;

            HttpResponseMessage response;
            _transaction.EmployeeId = LoadSelectedEmployee(comboBoxEmployee.SelectedIndex).Id;
            if (_transaction.Id == 0)
            {
                response = await _client.PostAsJsonAsync("transaction", _transaction);
            }
            else
            {
                response = await _client.PutAsJsonAsync("transaction", _transaction);
            }
            response.EnsureSuccessStatusCode();
            Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await LoadFormServerEmployeeList();
            RefreshEmployeeList();
            RefreshGridViewTransactionList();
        }

        private void SetDataBindings()
        {

            txtCustomer.DataBindings.Add(new Binding("Text", bsTransaction, "CustomerFullName", true));
            numTotalValue.DataBindings.Add(new Binding("Text", bsTransaction, "TotalValue", true));


            //TODO elen3e an ta bindings einai swsta
            RefreshEmployeeList();
            comboBoxEmployee.DataBindings.Add(new Binding("Text", bsTransaction, "EmployeeFullName", true));

            string[] payMethod = Enum.GetNames(typeof(PaymentMethod));
            comboBoxPaymentMethod.Items.AddRange(payMethod);

            comboBoxPaymentMethod.DataBindings.Add(new Binding("Text", bsTransaction, "PayMentMethod", true));
        }

        private async Task LoadFormServerEmployeeList()
        {
            var employees = await _client.GetFromJsonAsync<List<EmployeeViewModel>>("employee");
            _currEmployees = employees.Where(e => e.HireDateStart <= DateTime.Now &&
                e.HireDateEnd > DateTime.Now && e.EmployeeType != EmployeeType.Staff).ToList();

        }

        private async Task LoadFromServerCustomer()
        {
            var tmp = await _client.GetFromJsonAsync<CustomerViewModel>($"customer/{_transaction.CustomerId}");
            if (tmp is null) return;
            _transaction.CustomerFullName = $"{tmp.Name} {tmp.Surname}";
        }

        private EmployeeViewModel LoadSelectedEmployee(int selectedIndex)
        {
            return _currEmployees.ElementAt(selectedIndex);
        }

        private void SetReadOnlyFields()
        {
            txtCustomer.ReadOnly = true;
            numTotalValue.ReadOnly = true;
            grvTransaction.ReadOnly = true;
        }

        private void RefreshEmployeeList()
        {
            comboBoxEmployee.DataSource = null;
            comboBoxEmployee.DataSource = _currEmployees;
            comboBoxEmployee.DisplayMember = "FullName";
            comboBoxEmployee.ValueMember = "Id";
        }

        private void RefreshGridViewTransactionList()
        {
            grvTransaction.DataSource = null;

            grvTransaction.DataSource = _transaction.TransactionLineList;
            grvTransaction.Update();
            grvTransaction.Refresh();

            grvTransaction.Columns["TransactionId"].Visible = false;
            grvTransaction.Columns["Id"].Visible = false;
            grvTransaction.Columns["ItemId"].Visible = false;

            TotalValueCalc();
        }

        private void TotalValueCalc()
        {
            _transaction.TotalValue = _handler.CalculateTransactionTotalValue(_transaction.TransactionLineList);
            numTotalValue.Text = _transaction.TotalValue.ToString();
            SetPaymentMethod(_transaction.TotalValue);
        }

        private void SetPaymentMethod(decimal totalValue)
        {
            comboBoxPaymentMethod.Enabled = true;
            if (!_handler.CheckCardPaymentAvail(totalValue))
            {
                comboBoxPaymentMethod.SelectedIndex = 1;
                comboBoxPaymentMethod.Enabled = false;
            }
        }
    }
}
