using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_14.Model
{
    public class TransactionLine : Item
    {
        public Guid TransactionID { get; set; }
        public Guid ServiceTaskID { get; set; }
        public Guid EngineerID { get; set; }
        public decimal Hours { get; set; }
        public decimal PricePerHour { get; }
        public decimal Price { get; set; }
        public Transaction Transaction { get; set; }

        public TransactionLine()
        {
            PricePerHour = 44.5m;
        }

    }
}
