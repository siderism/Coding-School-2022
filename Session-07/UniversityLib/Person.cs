using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityLibrary
{
    [Serializable]
    public class Person
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public Person()
        {
            ID = Guid.NewGuid();
        }
    }
}
