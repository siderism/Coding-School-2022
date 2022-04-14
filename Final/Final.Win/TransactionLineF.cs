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
    public partial class TransactionLineF : Form
    {
        private TransactionLineViewModel _transactionLine;
        private TransactionEditViewModel _transaction;
        private HttpClient _client;
        private TransactionHandler _handler;
        private List<ItemViewModel> _items;
        public TransactionLineF(HttpClient http, TransactionEditViewModel transaction, TransactionHandler transactionHandler)
        {
            InitializeComponent();
            _client = http;
            _transaction = transaction;
            _handler = transactionHandler;
        }

        public TransactionLineF(HttpClient http, TransactionLineViewModel transactionLine, TransactionEditViewModel transaction, TransactionHandler transactionHandler) : this(http, transaction, transactionHandler)
        {
            _transactionLine = transactionLine;
            _handler = transactionHandler;
        }

        private async void TransactionLineF_Load(object sender, EventArgs e)
        {
            if (_transactionLine is null)
            {
                _transactionLine = new TransactionLineViewModel();
            }
            bsTransactionLine.DataSource = _transactionLine;
            await LoadItemFromServer();

            SetDataBindigs();
        }

        private async Task LoadItemFromServer()
        {
            _items = await _client.GetFromJsonAsync<List<ItemViewModel>>("item");
            if(_items is null)
            {
                return;
            }
            if (_handler.CheckFuelExist(_transaction.TransactionLineList, _items))
            {
                _items = _items.Where(i => i.ItemType != ItemType.Fuel).ToList();
            }
        }

        private void RefreshItemList()
        {
            comboBoxItem.DataSource = null;
            comboBoxItem.DataSource = _items;
            comboBoxItem.DisplayMember = "Description";
            comboBoxItem.ValueMember = "Id";
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await LoadItemFromServer();
            RefreshItemList();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(comboBoxItem.Text) || numQuantity.Value <= 0)
                return;
            if (_transactionLine.Id == 0)
            {
                _transactionLine.ItemPrice = _items.ElementAt(comboBoxItem.SelectedIndex).Price;
                _transactionLine.NetValue = _handler.CalculateNetValue(_transactionLine.Quantity, _transactionLine.ItemPrice);

                if (_items.ElementAt(comboBoxItem.SelectedIndex).ItemType == ItemType.Fuel)
                {
                    _transactionLine.DiscountValue = _handler.ApplyTenPercentDiscount(_transactionLine.NetValue);
                    if (_transactionLine.DiscountValue > 0)
                    {
                        _transactionLine.DiscountPercent = 0.1m;
                    } 
                }
                _transactionLine.TotalValue = _handler.CalculateLineTotalValue(_transactionLine.DiscountValue, _transactionLine.NetValue);
                _transaction.TransactionLineList.Add(ConvertToTransactionLine(_transactionLine));
            }
            else
            {
                var item = _transaction.TransactionLineList.FirstOrDefault(tl => tl.Id == _transactionLine.Id);
                item = ConvertToTransactionLine(_transactionLine);
            }
            Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private TransactionLineEditViewModel ConvertToTransactionLine(TransactionLineViewModel model)
        {
            return new TransactionLineEditViewModel()
            {
                Id = model.Id,
                DiscountPercent = model.DiscountPercent,
                DiscountValue = model.DiscountValue,
                ItemId = _items.ElementAt(comboBoxItem.SelectedIndex).Id,
                Quantity = model.Quantity,
                ItemPrice = model.ItemPrice,
                NetValue = model.NetValue,
                TotalValue = model.TotalValue,
                ItemDescription = model.ItemDescription,
            };
        }

        private void SetDataBindigs()
        {
            RefreshItemList();

            comboBoxItem.DataBindings.Add(new Binding("Text", bsTransactionLine, "ItemDescription", true));

            numQuantity.DataBindings.Add(new Binding("Text", bsTransactionLine, "Quantity", true));
        }
    }
}
