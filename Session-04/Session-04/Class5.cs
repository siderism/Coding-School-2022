using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_04
{
    public class Class5
    {
        public Class5()
        {
              
        }

        public int[] SortedArray(int[] array)
        {
            int temp;
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - 1; j++)
                {
                    if (array[j] > array[j+1])
                    {
                        temp = array[j + 1];
                        array[j+1] = array[j];
                        array[j] = temp;
                    }
                }
            }
            return array;
        }
    }
}
