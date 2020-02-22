using System;
using System.Collections.Generic;
using System.Linq;
using Payslip_Round_2.IO;

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
            
            var userChoice = UserInput.GetChoiceOfManualOrCsv();
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

        private List<Payslip> CreatePayslipFromCsv()
        {
            var filename = UserInput.GetCsvFilename();
            return PayslipFactory.MakePayslip(filename);
        }

        private static Payslip CreatePayslipManually()
        {
            var employee = UserInput.CreateEmployeeManually();
            var payPeriod = UserInput.GetPayPeriodManually();
            return PayslipFactory.MakePayslip(employee, payPeriod);
        }

        private void DisplayPayslips(List<Payslip> payslips)
        {
            var userChoice = UserInput.GetUserOutputFormatChoice();
            switch (userChoice)
            {
                case "console":
                    ConsoleDisplayAllPayslips(payslips);
                    break;
                case "csv":
                    var outputFileName = UserInput.GetCsvFilename();
                    WritePayslipsToCsv(payslips, outputFileName);
                    break;
            }
        }
        private static void ConsoleDisplayAllPayslips(List<Payslip> payslips)
        {
            foreach (var payslip in payslips)
            {
                Display.DisplayPayslip(payslip);
                Display.AlertUser(Environment.NewLine);
            }
        }

        private static void WritePayslipsToCsv(List<Payslip> payslips, string filename)
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