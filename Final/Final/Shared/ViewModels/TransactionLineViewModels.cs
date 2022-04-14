using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.Shared.ViewModels
{
    public class TransactionLineViewModel
    {
        public int Id { get; set; }
        public string ItemDescription { get; set; }

        public int Quantity { get; set; }

        public decimal ItemPrice { get; set; }

        public decimal NetValue { get; set; }

        public decimal DiscountPercent { get; set; }

        public decimal DiscountValue { get; set; }

        public decimal TotalValue { get; set; }
    }

    public class TransactionLineEditViewModel
    {
        public int Id { get; set; }
        public int ItemId { get; set; }

        public string ItemDescription { get; set; }

        public int TransactionId { get; set; }
        public int Quantity { get; set; }

        public decimal ItemPrice { get; set; }

        public decimal NetValue { get; set; }

        public decimal DiscountPercent { get; set; }

        public decimal DiscountValue { get; set; }

        public decimal TotalValue { get; set; }
    }
}
