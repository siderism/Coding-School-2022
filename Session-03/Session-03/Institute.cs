using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_03
{
    public class Institute
    {
        public Guid ID { get; }
        public string Name { get; set; }
        public int YearsInService { get; set; }

        public Institute(string name)
        {
            ID = Guid.NewGuid();
            Name = name;
        }

        public string GetName()
        {
            return Name;
        }

        public void SetName(string name)
        {
            Name = name;
        }
    }
}
