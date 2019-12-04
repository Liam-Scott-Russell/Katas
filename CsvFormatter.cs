using System;

namespace Payslip_Round_2
{
    public class CsvFormatter
    {
        public static Employee ExtractEmployee(string csvLine)
        {
            var separated = csvLine.Split(Config.CsvDelimiter);
            
            var employee = new Employee()
            {
                Firstname = separated[0],
                Lastname = separated[1],
                Salary = ConvertSalary(separated[2]),
                SuperPercent = ConvertSuper(separated[3])
            };

            return employee;
        }

        private static decimal ConvertSalary(string salary)
        {
            return Convert.ToDecimal(salary);
        }

        private static decimal ConvertSuper(string super)
        {
            var superWithoutPercentSign = super.Replace("%", "");
            return Convert.ToDecimal(superWithoutPercentSign);
        }

        public static PayPeriod ExtractPayPeriod(string csvLine)
        {
            var separatedFields = csvLine.Split(Config.CsvDelimiter);
            var separatedPayPeriod = separatedFields[4].Split("–");
            
            var payPeriod = new PayPeriod()
            {
                Start = FormatDate(separatedPayPeriod[0]),
                End = FormatDate(separatedPayPeriod[1])
            };

            return payPeriod;
        }

        private static DateTime FormatDate(string inputDate)
        {
            var trimmedDate = inputDate.Trim();
            return DateTime.ParseExact(trimmedDate, Config.DateInputFormat, null);
        }
    }
}