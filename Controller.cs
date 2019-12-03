using System;
using System.Collections.Generic;

namespace Payslip_Round_2
{
    public class Controller
    {

        public void Begin()
        {
            var payslips = new List<Payslip>();
            
            var userChoice = GetChoiceOfManualOrCsv();
            switch (userChoice)
            {
                case "manual":
                    var payslip = CreatePayslipManually();
                    payslips.Add(payslip);
                    break;
                case "csv":
                    payslips.AddRange(CreatePayslipFromCsv());
                    break;
            }

            foreach (var payslip in payslips)
            {
                Display.DisplayPayslip(payslip);
                Display.AlertUser(Environment.NewLine);
            }
        }

        private string GetChoiceOfManualOrCsv()
        {
            Display.AlertUser("Type 'csv' or 'manual' to specify input type");
            return Display.GetUserInput();
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
            employee.Firstname = Display.GetUserInput();
            
            Display.AlertUser("Please input your surname:");
            employee.Lastname = Display.GetUserInput();
            
            Display.AlertUser("Please enter your annual salary:");
            employee.Salary = Convert.ToDecimal(Display.GetUserInput());
            
            Display.AlertUser("Please enter your super rate:");
            employee.SuperPercent = Convert.ToDecimal(Display.GetUserInput());

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
            return Convert.ToDateTime(Display.GetUserInput());
        }

        private DateTime GetUserInputPaymentEnd()
        {
            Display.AlertUser("Please enter your payment end date:");
            return Convert.ToDateTime(Display.GetUserInput());
        }
    }
}