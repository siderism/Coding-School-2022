using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_04
{
    public class Class1
    {
        public Class1()
        {

        }

        public string Reverse(string name)
        {
            string reverseName = String.Empty;
            for (int i = name.Length - 1; i >= 0; i--)
            {
                reverseName += name[i];
            }
            return reverseName;
        }
    }
}
