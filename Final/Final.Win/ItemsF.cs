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
    public partial class ItemsF : Form
    {
        private HttpClient _client;
        private List<ItemViewModel> _itemList;
        private ItemViewModel _selectedItem;
        public ItemsF(HttpClient httpClient)
        {
            InitializeComponent();
            _client = httpClient;
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            var frmCustomerList = new ItemEditF(_client);
            frmCustomerList.ShowDialog();
            await RefreshItemList();
        }

        private async void btnEdit_Click(object sender, EventArgs e)
        {
            if (grdItems.SelectedRows.Count != 1)
                return;

            _selectedItem = (ItemViewModel)grdItems.SelectedRows[index: 0].DataBoundItem;
            var frmCustomerList = new ItemEditF(_client, _selectedItem);
            frmCustomerList.ShowDialog();
            await RefreshItemList();
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (grdItems.SelectedRows.Count != 1)
                return;

            _selectedItem = (ItemViewModel)grdItems.SelectedRows[index: 0].DataBoundItem;
            _client.DeleteAsync($"item/{_selectedItem.Id}");
            await RefreshItemList();
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await RefreshItemList();
        }

        private async void ItemsF_Load(object sender, EventArgs e)
        {
            await RefreshItemList();

            grdItems.ReadOnly = true;
        }

        private async Task LoadItemsFromServer()
        {
            _itemList = await _client.GetFromJsonAsync<List<ItemViewModel>>("item");
        }

        private async Task RefreshItemList()
        {
            grdItems.DataSource = null;

            await LoadItemsFromServer();
            grdItems.DataSource = _itemList;

            grdItems.Update();
            grdItems.Refresh();
            grdItems.Columns["Id"].Visible = false;
            SetOrderItemGridView();
        }

        private void SetOrderItemGridView()
        {
            grdItems.Columns["Description"].DisplayIndex = 0;
            grdItems.Columns["Code"].DisplayIndex = 1;
            grdItems.Columns["ItemType"].DisplayIndex = 2;
            grdItems.Columns["Cost"].DisplayIndex = 3;
            grdItems.Columns["Price"].DisplayIndex = 4;
        }
    }
}
