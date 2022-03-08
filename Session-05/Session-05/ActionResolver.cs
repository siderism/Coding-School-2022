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
                            MessageString = $"Converted decimal input {decimalInput} to binary {inputInBinary}."
                        };
                        Logger.Write(message.MessageString);
                    }
                    catch (Exception e)
                    {
                        var message = new Message()
                        {
                            MessageString = e.Message
                        };
                        Logger.Write(message.MessageString);
                        actionResponse.Output = String.Empty;
                    }
                    break;
                case ActionEnum.Uppercase:
                    if (actionRequest.Input is string)
                    {
                        var message = new Message();
                        if (WordsInInput(actionRequest.Input) > 1)
                        {
                            actionResponse.Output = FindLongestWord(actionRequest.Input).ToUpper();
                            message.MessageString = "Turned from lower case to upper case the longest word of given input.";
                        }
                        else
                        {
                            actionResponse.Output = actionRequest.Input.ToUpper();
                            message.MessageString = "Turned from lower case to upper case the given input.";
                        }
                        Logger.Write(message.MessageString);
                    }
                    else
                    {
                        var message = new Message()
                        {
                            MessageString = "The given input wasn't string type."
                        };
                        Logger.Write(message.MessageString);
                        actionResponse.Output = string.Empty;
                    }
                    break;
                case ActionEnum.Reverse:
                    if (actionRequest.Input is string)
                    {
                        var message = new Message()
                        {
                            MessageString = "Reversed the given string."
                        };
                        actionResponse.Output = GetReversed(actionRequest.Input);
                        Logger.Write(message.MessageString);
                    }
                    else
                    {
                        var message = new Message()
                        {
                            MessageString = "The given input wasn't string type."
                        };
                        Logger.Write(message.MessageString);
                        actionResponse.Output = String.Empty;
                    }
                    break;
                default:
                    var errorMessage = new Message()
                    {
                        MessageString = "The given Action was not valid."
                    };
                    Logger.Write(errorMessage.MessageString);
                    actionResponse.Output = String.Empty;
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

        private string GetReversed(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

    }
}
