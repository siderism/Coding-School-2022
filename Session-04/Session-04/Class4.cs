using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_04
{
    public class Class4
    {
        public Class4()
        {

        }

        public int[] MultiplyArray(int[] arrayA, int[] arrayB)
        {
            int resultLength = arrayA.Length * arrayB.Length;
            int[] result = new int[resultLength];
            int counter = 0;
            for (int i = 0; i < arrayA.Length; i++)
            {
                for (int j = 0; j < arrayB.Length; j++)
                {
                    result[counter] = arrayA[i] * arrayB[j];
                    counter++;
                }
            }
            return result;
        }
    }
}
