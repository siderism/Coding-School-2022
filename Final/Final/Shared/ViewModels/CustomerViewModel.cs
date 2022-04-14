using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.Shared.ViewModels
{
    public class CustomerViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FullName { get { return $"{Name} {Surname}"; } }
        public string CardNumber { get; set; }
    }

    public class CustomerEditViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FullName { get { return $"{Name} {Surname}"; } }
        public string CardNumber { get; set; } = String.Empty;
    }

    public class CustomerListViewModel
    {
        public List<CustomerEditViewModel> CustomerList { get; set; } = new List<CustomerEditViewModel>();
    }
}
