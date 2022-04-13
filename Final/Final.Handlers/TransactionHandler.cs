using Final.EF.Context;
using Final.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.Handlers
{
    public class TransactionHandler
    {
        private readonly FinalContext _context;

        public TransactionHandler(FinalContext context)
        {
            _context = context;
        }

        public decimal CalculateNetValue(int quantity, decimal price)
        {
            return quantity * price;
        }

        public decimal CalculateDiscountValue(decimal netValue, decimal discountPercent)
        {
            return netValue * discountPercent;
        }

        public decimal CalculateLineTotalValue(decimal discountValue, decimal netValue)
        {
            return netValue - discountValue;
        }

        public decimal CalculateTransactionTotalValue(List<decimal> linesTotalValues)
        {
            return linesTotalValues.Sum();
        }

        public decimal ApplyTenPercentDiscount(decimal netValue, decimal totalValue)
        {
            if (netValue > 20)
            {
                return totalValue - totalValue * 0.10m;
            }
            return totalValue;
        }

        public bool CheckFuelExist(List<TransactionLine> transactionLines)
        {
            return transactionLines.Where(x => x.Item?.ItemType == ItemType.Fuel).Any();
        }

        public bool CheckCardPaymentAvail(decimal totalValue)
        {
            return totalValue <= 50;
        }
    }
}
