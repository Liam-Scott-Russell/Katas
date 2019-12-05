using System.Collections.Generic;
using Payslip_Round_2.IO;

namespace Payslip_Round_2
{
    public class PayslipFactory
    {
        public static Payslip MakePayslip(Employee employee, PayPeriod payPeriod)
        {
            return CreatePayslipObject(employee, payPeriod);
        }
        
        public static List<Payslip> MakePayslip(string csvFileName)
        {
            var allPayslips = new List<Payslip>();
            var lines = CsvReaderWriter.ReadLines(csvFileName);

            for (var i = 1; i < lines.Length; i++)
            {
                var line = lines[i];
                var employee = CsvFormatter.ExtractEmployee(line);
                employee.Country = Config.Australia; // TODO: Remove this hardcoded value once we have config input
                
                var payPeriod = CsvFormatter.ExtractPayPeriod(line);
                var payslip = CreatePayslipObject(employee, payPeriod);
                
                allPayslips.Add(payslip);
            }

            return allPayslips;
        }

        private static Payslip CreatePayslipObject(Employee employee, PayPeriod payPeriod)
        {
            var calculator = new TaxCalculator(employee);
            return new Payslip()
            {
                Employee = employee,
                PayPeriod = payPeriod,
                TaxInformation = new TaxDetails()
                {
                    GrossIncome = calculator.GetGrossIncome(),
                    IncomeTax = calculator.GetIncomeTax(),
                    NetIncome = calculator.GetNetIncome(),
                    SuperAmount = calculator.GetSuperAmount()
                }
            };
        }
    }
}