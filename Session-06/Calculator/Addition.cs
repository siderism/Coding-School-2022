using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Addition : BaseExecute
    {
        public decimal Number1 { get; set; }
        public decimal Number2 { get; set; }

        public Addition(decimal num1, decimal num2)
        {
            Number1 = num1;
            Number2 = num2;
        }

        public override string Execute()
        {
            decimal result = Number1 + Number2;
            return result.ToString();
        }
    }
}
