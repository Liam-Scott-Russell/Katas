using System;

namespace Payslip_Round_2
{
    public class Formatter
    {
        public static DateTime ParseDateString(string inputDate)
        {
            var trimmedDate = inputDate.Trim();
            return DateTime.ParseExact(trimmedDate, Config.DateInputFormat, null);
        }
        
        public static string ConcatenateEmployeeName(Employee employee)
        {
            return $"{employee.Firstname} {employee.Lastname}";
        }
        
        public static string ConcatenatePayPeriod(PayPeriod payPeriod)
        {
            var formattedStartDate = payPeriod.Start.ToString("MMMM dd");
            var formattedEndDate = payPeriod.End.ToString("MMMM dd");
            return $"{formattedStartDate} - {formattedEndDate}";
        }
    }
}