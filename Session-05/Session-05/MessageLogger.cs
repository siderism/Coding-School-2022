using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_05
{
    public class MessageLogger
    {
        public Message[] Messsages { get; set; }

        public MessageLogger()
        {
            Messsages = new Message[200];
        }

        public void ReadAll()
        {
            foreach (var message in Messsages)
            {
                Console.WriteLine(message.MessageString);
            }
        }

        public void Clear()
        {
            for (int i = 0; i < Messsages.Length; i++)
            {
                Messsages[i] = new Message();
            }
        }

        public void Write(Message message)
        {
            for (int i = 0; i < Messsages.Length; i++)
            {
                if (Messsages[i].MessageString == null)
                {
                    Messsages[i] = new Message
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
