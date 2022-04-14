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
    public partial class CustomerEditF : Form
    {
        private CustomerEditViewModel _customer;
        private HttpClient _client;

        public CustomerEditF(HttpClient client)
        {
            InitializeComponent();
            _client = client;
        }

        public CustomerEditF(HttpClient client, CustomerEditViewModel customer) : this(client)
        {
            _customer = customer;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxName.Text) || string.IsNullOrWhiteSpace(textBoxSurname.Text))
                return;

            if (_customer.Id == 0)
            {
                var response = await _client.PostAsJsonAsync("customer", _customer);
            }
            else
            {
                var response = await _client.PutAsJsonAsync("customer", _customer);
            }
            Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CustomerEditF_Load(object sender, EventArgs e)
        {
            if (_customer == null)
            {
                _customer = new CustomerEditViewModel();
            }
            bsCustomer.DataSource = _customer;

            SetDataBindings();
        }

        private void SetDataBindings()
        {
            textBoxName.DataBindings.Add(new Binding("Text", bsCustomer, "Name", true));
            textBoxSurname.DataBindings.Add(new Binding("Text", bsCustomer, "Surname", true));
        }

    }
}
