using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class ToPower : BaseExecute
    {
        public double Number1 { get; set; }
        public double Number2 { get; set; }

        public ToPower(double num1, double num2)
        {
            Number1 = num1;
            Number2 = num2;
        }

        public override string Execute()
        {
            double result = Math.Pow(Number1, Number2);
            return result.ToString();
        }
    }
}
