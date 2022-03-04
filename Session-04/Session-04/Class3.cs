using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_04
{
    public class Class3
    {
        public Class3()
        {

        }

        public void FindPrimes(int n)
        {
            for (int i = 2; i <= n; i++)
            {
                bool isPrime = true;
                for (int j = 2; j <= i/2; j++)
                {
                    if (i%j == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime)
                {
                    Console.Write($"{i} ");
                }
            }
        }
    }
}
