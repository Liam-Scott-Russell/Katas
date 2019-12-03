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
    }
}