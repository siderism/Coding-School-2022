using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class SquareRoot : BaseExecute
    {
        public double Number { get; set; }

        public SquareRoot(double num)
        {
            Number = num;
        }

        public override string Execute()
        {
            double result = Math.Sqrt(Number);
            return result.ToString();
        }
    }
}
