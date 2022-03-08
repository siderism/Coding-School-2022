using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_05
{
    public class MessageLogger
    {
        public Message[] Messages { get; set; }

        public MessageLogger()
        {
            Messages = new Message[200];
        }

        public void ReadAll()
        {
            foreach (var message in Messages)
            {
                Console.WriteLine(message.MessageString);
            }
        }

        public void Clear()
        {
            Array.Clear(Messages, 0, Messages.Length);
        }

        public void Write(Message message)
        {
            for (int i = 0; i < Messages.Length; i++)
            {
                if (Messages[i] == null)
                {
                    Messages[i] = new Message
                    {
                        MessageString = message.MessageString,
                        ID = message.ID,
                        TimeStamp = message.TimeStamp
                    };
                    break;
                }
            }
        }
    }
}
