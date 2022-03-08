using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_05
{
    public class Message
    {
        public Guid ID { get; set; }
        public DateTime TimeStamp { get; set; }
        public string MessageString { get; set; }

        public Message()
        {
            ID = Guid.NewGuid();
            TimeStamp = DateTime.Now;
        }
    }
}
