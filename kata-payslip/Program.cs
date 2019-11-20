using System;

namespace kata_payslip
{
     class Program
     {
          static void Main(string[] args)
          {
               // Gets input from the user
               Console.WriteLine("Welcome to the payslip generator!\n");
               Console.WriteLine("Please input your name: ");
               string firstName = Console.ReadLine();
               Console.WriteLine("Please input your surname: ");
               string lastName = Console.ReadLine();
               Console.WriteLine("Please enter your annual salary: ");
               int salary = Convert.ToInt32(Console.ReadLine());
               Console.WriteLine("Please enter your super: ");
               int superPercent = Convert.ToInt32(Console.ReadLine());
               Console.WriteLine("Please enter your payment start date: ");
               string startDate = Console.ReadLine();
               Console.WriteLine("Please enter your payment end date: ");
               string endDate = Console.ReadLine();

               // Instantiate a payslip object
               Payslip payslip = new Payslip(firstName, lastName, salary, superPercent, startDate, endDate);
               

               // Print the payslip
               Console.WriteLine("\nYour payslip has been generated: \n");
               Console.WriteLine($"Name: {payslip.FullName}");
               Console.WriteLine($"Pay Period: {payslip.PayPeriod}");
               Console.WriteLine($"Gross Income: {payslip.GrossIncome}");
               Console.WriteLine($"Income Tax: {payslip.Tax}");
               Console.WriteLine($"Net Income: {payslip.NetIncome}");
               Console.WriteLine($"Super: {payslip.Super}");
               Console.WriteLine("\nThank you for using MYOB!");
          }
          
          
     }

     public class Payslip
     {
          public Payslip(string firstName, string lastName, int salary, int superPercent, string startDate, string endDate)
          {
               this.FullName = $"{firstName} {lastName}";
               
               // Separates the input dates and gets the day and month
               // Also pads the date to two characters
               string month = startDate.Split(" ")[1];
               string startDay = startDate.Split(" ")[0].PadLeft(2, '0');
               string endDay = endDate.Split(" ")[0].PadLeft(2, '0');
               this.PayPeriod = $"{startDay} {month} - {endDay} {month}";
               
               // Calculates the monthly gross income
               this.GrossIncome = Math.Round((double) (salary / 12));
               
               // Calculates the tax on the salary
               double tax;
               if (salary <= 18200)
               {
                    tax = 0;
               }
               else if (salary <= 37000)
               {
                    tax = 0.19 * (salary - 18200);
               }
               else if (salary <= 87000)
               {
                    tax = 3572 + (0.325 * (salary - 37000));
               }
               else if (salary <= 180000)
               {
                    tax = 19822 + (0.37 * (salary - 87000));
               }
               else
               {
                    tax = 54232 + (0.42 * (salary - 180000));
               }

               this.Tax = Math.Round(tax / 12); // Makes the tax for one month
               
               // Calculate the super of the individual
               this.Super = Convert.ToInt32(this.GrossIncome * (superPercent / 100.0));

               // Calculates monthly net income
               this.NetIncome = this.GrossIncome - this.Tax;

          }
          
          //Properties
          public string FullName { get; set; }
          public string PayPeriod { get; set; }
          public double GrossIncome { get; set; }
          public double Tax { get; set; }
          public double NetIncome { get; set; }
          public double Super { get; set; }
     }
}