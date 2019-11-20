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
               string surName = Console.ReadLine();
               Console.WriteLine("Please enter your annual salary: ");
               int salary = Convert.ToInt32(Console.ReadLine());
               Console.WriteLine("Please enter your super: ");
               int superPercent = Convert.ToInt32(Console.ReadLine());
               Console.WriteLine("Please enter your payment start date: ");
               string startDate = Console.ReadLine();
               Console.WriteLine("Please enter your payment end date: ");
               string endDate = Console.ReadLine();

               // Re-orders some of the input so that it prints correctly
               string fullName = $"{firstName} {surName}";
               string month = startDate.Split(" ")[1];

               // Strip the days from the entered month, and pad them to 2 characters
               string startDay = startDate.Split(" ")[0].PadLeft(2, '0');
               string endDay = endDate.Split(" ")[0].PadLeft(2, '0');
               string payPeriod = $"{startDay} {month} - {endDay} {month}";


               // Calculate the gross income
               double grossIncome = Math.Round((double) (salary / 12));

               // Determine which tax bracket the salary is in
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

               tax = Math.Round(tax / 12); // Makes the tax for one month

               // Calculate the super of the individual
               int superAmount = Convert.ToInt32(grossIncome * (superPercent / 100.0));

               // Print the payslip
               Console.WriteLine("\nYour payslip has been generated: \n");
               Console.WriteLine($"Name: {fullName}");
               Console.WriteLine($"Pay Period: {payPeriod}");
               Console.WriteLine($"Gross Income: {grossIncome}");
               Console.WriteLine($"Income Tax: {tax}");
               Console.WriteLine($"Net Income: {grossIncome - tax}");
               Console.WriteLine($"Super: {superAmount}");
               Console.WriteLine("\nThank you for using MYOB!");
          }
     }
}