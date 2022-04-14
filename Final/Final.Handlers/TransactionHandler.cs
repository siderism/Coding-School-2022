using Final.EF.Context;
using Final.Model;
using Final.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.Handlers
{
    public class TransactionHandler
    {
        public TransactionHandler()
        {
        }

        public decimal CalculateNetValue(int quantity, decimal price)
        {
            return quantity * price;
        }

        public decimal CalculateLineTotalValue(decimal discountValue, decimal netValue)
        {
            return netValue - discountValue;
        }

        public decimal CalculateTransactionTotalValue(List<TransactionLineEditViewModel> linesTotalValues)
        {
            return linesTotalValues.Sum(x => x.TotalValue);
        }

        public decimal ApplyTenPercentDiscount(decimal netValue)
        {
            if (netValue > 20)
            {
                return netValue * 0.10m;
            }
            return 0m; ;
        }

        public bool CheckFuelExist(List<TransactionLineEditViewModel> transactionLines, List<ItemViewModel> items)
        {

            foreach (var tl in transactionLines)
            {
                var currItem = items.FirstOrDefault(i => i.Id == tl.ItemId);
                if (currItem is null) return false;
                if (currItem.ItemType == ItemType.Fuel)
                    return true;
            }
            return false;
        }

        public bool CheckCardPaymentAvail(decimal totalValue)
        {
            return totalValue <= 50;
        }
    }
}
