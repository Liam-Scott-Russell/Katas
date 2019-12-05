using System;
using System.Text.RegularExpressions;

namespace Payslip_Round_2
{
    public class InputValidator
    {
        public static string GetInput(string regex)
        {
            while (true)
            {
                var userInput = Display.GetUserInput();
                
                if (IsValidInput(userInput, regex))
                {
                    return userInput;
                }
            }
        }

        private static bool IsValidInput(string input, string regex)
        {
            var checker = new Regex(regex);
            return checker.IsMatch(input);
        }

        public static DateTime GetDate()
        {
            while (true)
            {
                var userInput = Display.GetUserInput();

                try
                {
                    var parsedDate = DateTime.ParseExact(userInput, Config.DateInputFormat, null);
                    return parsedDate;
                }
                catch (FormatException){}
            }
        }
    }
}