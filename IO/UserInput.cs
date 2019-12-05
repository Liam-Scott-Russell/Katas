using System;

namespace Payslip_Round_2.IO
{
    public static class UserInput
    {
        
        public static string GetChoiceOfManualOrCsv()
        {
            Display.AlertUser("Type 'csv' or 'manual' to specify input type");
            return InputValidator.GetInput(@"^csv|manual$");
        }

        private static DateTime GetUserInputPaymentStart()
        {
            Display.AlertUser("Please enter your payment start date:");
            return InputValidator.GetDate();
        }

        private static DateTime GetUserInputPaymentEnd()
        {
            Display.AlertUser("Please enter your payment end date:");
            return InputValidator.GetDate();
        }
        
        public static Employee CreateEmployeeManually()
        {
            var employee = new Employee();
            
            Display.AlertUser("Please input your name:");
            var firstname = InputValidator.GetInput(Config.Regex["name"]);
            
            Display.AlertUser("Please input your surname:");
            var lastname = InputValidator.GetInput(Config.Regex["name"]);
            
            Display.AlertUser("Please enter your annual salary:");
            var salary = Convert.ToDecimal(InputValidator.GetInput(Config.Regex["salary"]));
            
            Display.AlertUser("Please enter your super rate:");
            var superPercent = Convert.ToDecimal(InputValidator.GetInput(Config.Regex["super"]));

            return new Employee()
            {
                Firstname = firstname,
                Lastname = lastname,
                Salary = salary,
                Country = Config.Australia,
                SuperPercent = superPercent
            };
        }
        
        public static PayPeriod GetPayPeriodManually()
        {
            var payPeriod = new PayPeriod()
            {
                Start = GetUserInputPaymentStart(),
                End = GetUserInputPaymentEnd()
            };
            return payPeriod;
        }
        
        public static string GetUserOutputFormatChoice()
        {
            Display.AlertUser("Type 'console' or 'csv' to decide how to output the payslip(s)");
            return InputValidator.GetInput(@"^csv|console");
        }
        
        public static string GetCsvFilename()
        {
            Display.AlertUser("Please enter a filename for the CSV file");
            return InputValidator.GetInput(Config.Regex["csvFilePath"]); 
        }
    }
}