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
            var formattedStartDate = payPeriod.Start.ToString("MMMM dd");
            var formattedEndDate = payPeriod.End.ToString("MMMM dd");
            AlertUser($"Pay Period: {formattedStartDate} - {formattedEndDate}");
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