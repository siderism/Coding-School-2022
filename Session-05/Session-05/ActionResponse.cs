using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_05
{
    public class ActionResponse
    {
        public Guid RequestID { get; set; }
        public Guid ResponseID { get; set; }
        public string Output { get; set; }

        public ActionResponse(Guid requestID)
        {
            RequestID = requestID;
            ResponseID = new Guid();
        }

    }
}
