using System;

namespace Payslip_Round_2
{
    public class Display
    {
        public static void AlertUser(string message)
        {
            Console.WriteLine(message);
        }

        public static string GetUserInput()
        {
            return Console.ReadLine();
        }
    }
}