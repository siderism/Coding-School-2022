using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Session_05.enums;

namespace Session_05
{
    public class ActionResolver : Executable
    {
        public MessageLogger Logger { get; set; }

        public ActionResolver()
        {
            Logger = new MessageLogger();
        }

        public override ActionResponse Execute(ActionRequest actionRequest)
        {
            var actionResponse = new ActionResponse(actionRequest.RequestID);
            switch (actionRequest.Action)
            {
                case ActionEnum.Convert:
                    try
                    {
                        int decimalInput = Convert.ToInt32(actionRequest.Input);
                        string inputInBinary = Convert.ToString(decimalInput, 2);
                        actionResponse.Output = inputInBinary;
                        var message = new Message()
                        {
                            MessageString = $"Converted decimal input {decimalInput} to binary {inputInBinary}"
                        };
                        Logger.Write(message);
                    }
                    catch (Exception e)
                    {
                        var message = new Message()
                        {
                            MessageString = e.Message
                        };
                        Logger.Write(message);
                        actionResponse.Output = String.Empty;
                    }
                    break;
                case ActionEnum.Uppercase:
                    if (actionRequest.Input.GetType() == typeof(string))
                    {
                        if (WordsInInput(actionRequest.Input) > 1)
                        {
                            actionResponse.Output = FindLongestWord(actionRequest.Input).ToUpper();
                        }
                        else
                        {
                            actionResponse.Output = actionRequest.Input.ToUpper();
                        }
                    }
                    break;
                case ActionEnum.Reverse:
                    if (actionRequest.Input.GetType() == typeof(string))
                    {
                        actionResponse.Output = GetReversed(actionRequest.Input);
                    }
                    break;
                default:
                    break;
            }
            return actionResponse;
        }

        private int WordsInInput(string input)
        {
            return input.Split(' ').Length;
        }

        private string FindLongestWord(string input)
        {
            string[] words = input.Split(' ');
            string longestWord = words[0];
            for (int i = 1; i < words.Length; i++)
            {
                if (words[i].Length > longestWord.Length)
                {
                    longestWord = words[i];
                }
            }
            return longestWord;
        }

        private string GetReversed(string str)
        {
            if (str.Length > 0)
                return str[str.Length - 1] + GetReversed(str.Substring(0, str.Length - 1));
            else
                return str;
        }

    }
}
