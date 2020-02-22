using System;

namespace Payslip_Round_2.IO
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

        public static void DisplayPayslip(Payslip payslip)
        {
            DisplayEmployeeInfo(payslip.Employee);
            DisplayPayPeriod(payslip.PayPeriod);
            DisplayTaxInformation(payslip.TaxInformation);
        }

        private static void DisplayEmployeeInfo(Employee employee)
        {
            var fullName = $"{employee.Firstname} {employee.Lastname}";
            AlertUser($"Name: {fullName}");
        }

        private static void DisplayPayPeriod(PayPeriod payPeriod)
        {
            var formattedDate = Formatter.ConcatenatePayPeriod(payPeriod);
            AlertUser($"Pay Period: {formattedDate}");
        }

        private static void DisplayTaxInformation(TaxDetails taxInfo)
        {
            AlertUser($"Gross Income: {taxInfo.GrossIncome}");
            AlertUser($"Income Tax: {taxInfo.IncomeTax}");
            AlertUser($"Net Income: {taxInfo.NetIncome}");
            AlertUser($"Super: {taxInfo.SuperAmount}");
        }
    }
}