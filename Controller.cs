using System;

namespace Payslip_Round_2
{
    public class Controller
    {

        public void Begin()
        {
            var payslip = new Payslip();
            
            var userChoice = GetChoiceOfManualOrCsv();
            switch (userChoice)
            {
                case "manual":
                    var employee = CreateEmployeeFromManualInput();
                    payslip = PayslipFactory.MakePayslip(employee);
                    break;
                case "csv":
                    var filename = GetCsvFilename();
                    payslip = PayslipFactory.MakePayslip(filename);
                    break;
            }
            
            var startDate = GetPaymentStartDate();
            var endDate = GetPaymentEndDate();
        }

        private string GetChoiceOfManualOrCsv()
        {
            Display.AlertUser("Type 'csv' or 'manual' to specify input type");
            return Display.GetUserInput();
        }

        private string GetCsvFilename()
        {
            Display.AlertUser("Please enter a filename for the CSV file");
            return Display.GetUserInput();
        }

        private Employee CreateEmployeeFromManualInput()
        {
            var employee = new Employee();
            
            Display.AlertUser("Please input your name:");
            employee.Firstname = Display.GetUserInput();
            
            Display.AlertUser("Please input your surname:");
            employee.Lastname = Display.GetUserInput();
            
            Display.AlertUser("Please enter your annual salary:");
            employee.Salary = Convert.ToDouble(Display.GetUserInput());
            
            Display.AlertUser("Please enter your super rate:");
            employee.SuperPercent = Convert.ToDouble(Display.GetUserInput());

            return employee;
        }

        private DateTime GetPaymentStartDate()
        {
            Display.AlertUser("Please enter your payment start date:");
            return Convert.ToDateTime(Display.GetUserInput());
        }

        private DateTime GetPaymentEndDate()
        {
            Display.AlertUser("Please enter your payment end date:");
            return Convert.ToDateTime(Display.GetUserInput());
        }
    }
}