using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.Model
{
    public class Employee : Entity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FullName { get { return $"{Name} {Surname}"; } }
        public DateTime HireDateStart { get; set; }
        public DateTime HireDateEnd { get; set; }
        public decimal SallaryPerMonth { get; set; }
        public EmployeeType EmployeeType { get; set; }
        public List<Transaction> Transactions { get; set; }
        public Employee()
        {

        }
    }
}
