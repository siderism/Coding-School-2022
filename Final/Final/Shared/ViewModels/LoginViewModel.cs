using Final.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.Shared.ViewModels
{
    public class LoginViewModel
    {
        public string Username { get; set; }
        public EmployeeType Role { get; set; }
        public bool IsAuth { get; set; }
    }
}
