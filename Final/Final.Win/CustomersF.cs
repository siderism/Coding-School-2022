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
    public partial class CustomersF : Form
    {
        private HttpClient _client;
        private List<CustomerEditViewModel> _customerList;
        private CustomerEditViewModel? _selectedCustomer;
        public CustomersF(HttpClient myhttpClient)
        {
            InitializeComponent();
            _client = myhttpClient;
        }

        private async void CustomersF_Load(object sender, EventArgs e)
        {
            await RefreshCustomerList();

            grdCustomerList.ReadOnly = true;
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            var frmCustomerList = new CustomerEditF(_client);
            frmCustomerList.ShowDialog();
            await RefreshCustomerList();
        }

        private async void btnEdit_Click(object sender, EventArgs e)
        {
            if (grdCustomerList.SelectedRows.Count != 1)
                return;

            _selectedCustomer = (CustomerEditViewModel)grdCustomerList.SelectedRows[index: 0].DataBoundItem;
            var frmCustomerList = new CustomerEditF(_client, _selectedCustomer);
            frmCustomerList.ShowDialog();
            await RefreshCustomerList();
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (grdCustomerList.SelectedRows.Count != 1)
                return;

            _selectedCustomer = (CustomerEditViewModel)grdCustomerList.SelectedRows[index: 0].DataBoundItem;
            _client.DeleteAsync($"customer/{_selectedCustomer.Id}");
            await RefreshCustomerList();
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await RefreshCustomerList();
        }

        private async Task LoadItemsFromServer()
        {
            _customerList = await _client.GetFromJsonAsync<List<CustomerEditViewModel>>("customer");
        }

        private async Task RefreshCustomerList()
        {
            grdCustomerList.DataSource = null;

            await LoadItemsFromServer();
            grdCustomerList.DataSource = _customerList;

            grdCustomerList.Update();
            grdCustomerList.Refresh();
            grdCustomerList.Columns["ID"].Visible = false;
        }
    }
}
