using Final.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.Shared.ViewModels
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public string FullName { get { return $"{Name} {Surname}"; } }
        public EmployeeType EmployeeType { get; set; }
        public decimal SallaryPerMonth { get; set; }
        public DateTime HireDateStart { get; set; }
        public DateTime HireDateEnd { get; set; }
    }

    public class EmployeeListViewModel
    {
        public List<EmployeeViewModel> EmployeeList { get; set; } = new List<EmployeeViewModel>();
    }
}
