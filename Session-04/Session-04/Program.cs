using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1

            string myName = "Michael Sideris";
            var c1 = new Class1();
            string myNameReversed = c1.Reverse(myName);
            Console.WriteLine(myNameReversed);
            Console.WriteLine();

            //2

            Console.WriteLine("Give me an integer to calculate the sum and the product.");
            int num2 = Convert.ToInt32(Console.ReadLine());
            var c2 = new Class2();
            int sum = c2.Sum(num2);
            long product = c2.Product(num2);
            Console.WriteLine($"The sum of numbers from 1 to {num2} is {sum}.");
            Console.WriteLine($"The product of numbers from 1 to {num2} is {product}.");
            Console.WriteLine();

            //3

            Console.WriteLine("Give me an integer to find all the prime numbers.");
            int num3 = Convert.ToInt32(Console.ReadLine());
            var c3 = new Class3();
            Console.WriteLine($"The prime numbers from 1 to {num3} are:");
            c3.FindPrimes(num3);
            Console.WriteLine("\n\n");
      
            //4

            Console.WriteLine("The values of the result Array are:");
            int[] array1 = new int[] { 2, 4, 9, 12 };
            int[] array2 = new int[] { 1, 3, 7, 10 };
            var c4 = new Class4();
            int[] result = c4.MultiplyArray(array1, array2);
            for (int i = 0; i < result.Length - 1; i++)
            {
                Console.Write($"{result[i]} ");
            }
            Console.WriteLine("\n\n");

            //5

            int[] array = new int[] { 0, -2, 1, 20, -31, 50, -4, 17, 89, 100 };
            var c5 = new Class5();
            int[] sortedArray = new int[array.Length];
            sortedArray = c5.SortedArray(array);
            Console.WriteLine("The sorted array is:");
            for (int i = 0; i < sortedArray.Length; i++)
            {
                Console.Write($"{sortedArray[i]} ");
            }
            Console.WriteLine();
            Console.ReadLine(); 
        }
    }
}
