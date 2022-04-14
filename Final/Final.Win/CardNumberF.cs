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
    public partial class CardNumberF : Form
    {
        private string _cardNumber;
        private HttpClient _client;
        private TransactionHandler _handler;
        public CardNumberF(HttpClient client, TransactionHandler Handler)
        {
            InitializeComponent();
            _client = client;
            _handler = Handler;
        }

        private async void btnContinue_Click(object sender, EventArgs e)
        {
            _cardNumber = textBoxCardNumber.Text;

            if (!IsValid(_cardNumber))
            {
                MessageBox.Show("Invalid CardNumber", "Error", MessageBoxButtons.OKCancel);
                return;
            }

            this.Close();

            var customers = await _client.GetFromJsonAsync<List<CustomerEditViewModel>>("customer");
            var existingCustomer = customers.SingleOrDefault(c => c.CardNumber.Equals(_cardNumber));
            if (existingCustomer is null)
            {
                var newCustomer = new CustomerEditViewModel()
                {
                    CardNumber = _cardNumber,
                };
                var frameNewCustomer = new CustomerEditF(_client, newCustomer);
                frameNewCustomer.ShowDialog();


                customers = await _client.GetFromJsonAsync<List<CustomerEditViewModel>>("customer");
                existingCustomer = customers.SingleOrDefault(c => c.CardNumber.Equals(_cardNumber));

                if (existingCustomer is null) this.Close();

            }
            OpenTransaction(existingCustomer);
        }

        private void CardNumberF_Load(object sender, EventArgs e)
        {

        }

        private bool IsValid(string code)
        {
            if (code[0] != 'A')
                return false;
            if (code.Length != 8)
                return false;
            return true;
        }

        private void OpenTransaction(CustomerEditViewModel mycustomer)
        {
            var transaction = new TransactionEditViewModel()
            {
                CustomerId = mycustomer.Id,
                TotalValue = 0,
                TransactionLineList = new()
            };
            var frameNewCustomer = new TransactionEditF(_client, transaction, _handler);
            frameNewCustomer.ShowDialog();
        }
    }
}
