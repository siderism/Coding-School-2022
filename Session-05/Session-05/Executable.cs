using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_05
{
    public abstract class Executable
    {
        public Executable()
        {

        }

        public abstract ActionResponse Execute(ActionRequest actionRequest);
    }
}
