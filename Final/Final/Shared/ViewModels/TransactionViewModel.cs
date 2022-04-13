using Final.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.Shared.ViewModels
{
    public class TransactionViewModel
    {
        public int Id { get; set; }
        public string EmployeeFullName { get; set; }
        public string CustomerFullName { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public decimal TotalValue { get; set; }
    }
}
