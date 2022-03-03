using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_03
{
    public class Course
    {
        public Guid ID { get; }
        public string Code { get; set; }
        public string Subject { get; set; }

        public Course(string code = "", string subject = "")
        {
            ID = Guid.NewGuid();
            Code = code;
            Subject = subject;
        }
    }
}
