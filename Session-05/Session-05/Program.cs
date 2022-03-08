using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Give an Action between Convert, Uppercase and Reverse");
            string action = Console.ReadLine();
            Console.WriteLine("Give a string");
            string input = Console.ReadLine();
            var actionRequest = new ActionRequest(input, action);
            var resolver = new ActionResolver();
            ActionResponse response = resolver.Execute(actionRequest);
            Console.WriteLine($"Output response is {response.Output}");
            resolver.Logger.ReadAll();
            Console.ReadLine();
        }
    }
}
