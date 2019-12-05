using System;
using System.Collections.Generic;
using System.Linq;

namespace Payslip_Round_2
{
    public class Controller
    {

        public void Begin()
        {
            var payslips = CreatePayslips();
            DisplayPayslips(payslips);
        }

        private List<Payslip> CreatePayslips()
        {
            var payslips = new List<Payslip>();
            
            var userChoice = GetChoiceOfManualOrCsv();
            switch (userChoice)
            {
                case "manual":
                    payslips.Add(CreatePayslipManually());
                    break;
                case "csv":
                    payslips.AddRange(CreatePayslipFromCsv());
                    break;
            }

            return payslips;
        }

        private string GetChoiceOfManualOrCsv()
        {
            Display.AlertUser("Type 'csv' or 'manual' to specify input type");
            return InputValidator.GetInput(@"^csv|manual$");
        }

        private List<Payslip> CreatePayslipFromCsv()
        {
            var filename = GetCsvFilename();
            return PayslipFactory.MakePayslip(filename);
        }

        private string GetCsvFilename()
        {
            Display.AlertUser("Please enter a filename for the CSV file");
            return Display.GetUserInput();
        }

        private Payslip CreatePayslipManually()
        {
            var employee = CreateEmployeeManually();
            employee.Country = Config.Australia;
            var payPeriod = GetPayPeriodManually();
            return PayslipFactory.MakePayslip(employee, payPeriod);
        }

        private Employee CreateEmployeeManually()
        {
            var employee = new Employee();
            
            Display.AlertUser("Please input your name:");
            employee.Firstname = InputValidator.GetInput(Config.Regex["name"]);
            
            Display.AlertUser("Please input your surname:");
            employee.Lastname = InputValidator.GetInput(Config.Regex["name"]);
            
            Display.AlertUser("Please enter your annual salary:");
            employee.Salary = Convert.ToDecimal(InputValidator.GetInput(Config.Regex["salary"]));
            
            Display.AlertUser("Please enter your super rate:");
            employee.SuperPercent = Convert.ToDecimal(InputValidator.GetInput(Config.Regex["super"]));

            return employee;
        }

        private PayPeriod GetPayPeriodManually()
        {
            var payPeriod = new PayPeriod()
            {
                Start = GetUserInputPaymentStart(),
                End = GetUserInputPaymentEnd()
            };
            return payPeriod;
        }

        private DateTime GetUserInputPaymentStart()
        {
            Display.AlertUser("Please enter your payment start date:");
            return InputValidator.GetDate();
        }

        private DateTime GetUserInputPaymentEnd()
        {
            Display.AlertUser("Please enter your payment end date:");
            return InputValidator.GetDate();
        }

        private void DisplayPayslips(List<Payslip> payslips)
        {
            var userChoice = GetUserOutputFormatChoice();
            switch (userChoice)
            {
                case "console":
                    ConsoleDisplayAllPayslips(payslips);
                    break;
                case "csv":
                    var outputFileName = GetCsvFilename();
                    WritePayslipsToCsv(payslips, outputFileName);
                    break;
            }
        }
        private void ConsoleDisplayAllPayslips(List<Payslip> payslips)
        {
            foreach (var payslip in payslips)
            {
                Display.DisplayPayslip(payslip);
                Display.AlertUser(Environment.NewLine);
            }
        }

        private string GetUserOutputFormatChoice()
        {
            Display.AlertUser("Type 'console' or 'csv' to decide how to output the payslip(s)");
            return InputValidator.GetInput(@"^csv|console");
        }

        private void WritePayslipsToCsv(List<Payslip> payslips, string filename)
        {
            var lines = new List<string>()
            {
                "name,pay period,gross income,income tax,net income,super"
            };
            
            lines.AddRange(payslips.Select(payslip => CsvFormatter.CreateCsvLineFromPayslip(payslip)));
            CsvReaderWriter.WriteLines(filename, lines);
        }
    }
}