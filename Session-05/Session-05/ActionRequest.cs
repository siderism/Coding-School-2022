using Session_05.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_05
{
    public class ActionRequest
    {
        public Guid RequestID { get; set; }
        public string Input { get; set; }
        public ActionEnum Action { get; set; }

        public ActionRequest(string input, string action)
        {
            RequestID = Guid.NewGuid();
            Input = input;
            switch (action)
            {
                case "Convert":
                    Action = ActionEnum.Convert;
                    break;
                case "Uppercase":
                    Action = ActionEnum.Uppercase;
                    break;
                case "Reverse":
                    Action = ActionEnum.Reverse;
                    break;
                default:
                    break;
            }
        }
    }
}
