using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.Model
{
    public class Customer : Entity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FullName { get { return $"{Name} {Surname}"; } }
        public string CardNumber { get; set; }
        public List<Transaction> Transactions { get; set; }

        public Customer()
        {

        }
    }
}
