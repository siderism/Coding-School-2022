using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_04
{
    public class Class2
    {
        public Class2()
        {

        }

        public int Sum(int n)
        {
            int sum = 0;
            for (int i = 0; i <= n; i++)
            {
                sum += i;
            }
            return sum;
        }

        public long Product(int n)
        {
            long product = 1;
            for (int i = 2; i <= n; i++)
            {
                product *= i;
            }
            return product;
        }
    }
}
