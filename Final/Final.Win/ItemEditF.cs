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
    public partial class ItemEditF : Form
    {
        private ItemViewModel _item;
        private HttpClient _client;
        public ItemEditF(HttpClient client)
        {
            InitializeComponent();
            _client = client;
        }

        public ItemEditF(HttpClient client, ItemViewModel item) : this(client)
        {
            _item = item;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxDescription.Text) ||
                numCost.Value < 0 ||
                numPrice.Value < 0)
                return;

            if (_item.Id == 0)
            {
                var response = await _client.PostAsJsonAsync("item", _item);
            }
            else
            {
                var response = await _client.PutAsJsonAsync("item", _item);
            }
            Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ItemEditF_Load(object sender, EventArgs e)
        {
            if (_item == null)
            {
                _item = new ItemViewModel();
            }
            bsItem.DataSource = _item;

            SetDataBindings();
        }

        private void SetDataBindings()
        {
            textBoxDescription.DataBindings.Add(new Binding("Text", bsItem, "Description", true));
            numCost.DataBindings.Add(new Binding("Text", bsItem, "Cost", true));
            numPrice.DataBindings.Add(new Binding("Text", bsItem, "Price", true));

            string[] itemType = Enum.GetNames(typeof(ItemType));
            comboBoxItemType.Items.AddRange(itemType);

            comboBoxItemType.DataBindings.Add(new Binding("Text", bsItem, "ItemType", true));

        }
    }
}
