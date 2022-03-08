﻿using Session_05.enums;
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

        public ActionRequest()
        {
            RequestID = Guid.NewGuid();
        }
    }
}
