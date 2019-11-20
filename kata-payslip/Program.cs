using System;
using System.Collections.Generic;
using Microsoft.VisualBasic.FileIO;

namespace kata_payslip
{
     class Program
     {
          static void Main(string[] args)
          {
               Console.WriteLine("Type \"csv\" to import from csv, or anything else for manual input");
               string choice = Console.ReadLine();
               if (choice == "csv")
               {
                    Console.WriteLine("Please specify a filename");
                    // Use "../../../" as a prefix to get the right file
                    string fileName = Console.ReadLine();
                    
                    // Read the CSV data
                    CSV file = new CSV(fileName);
                    List<Payslip> payslips = file.Read();
                    
                    // Print the payslips to console
                    Console.Out.WriteLine("\nYour payslip has been generated:\n");
                    foreach (Payslip payslip in payslips)
                    {
                         payslip.Print();
                         Console.Out.WriteLine("\n");
                    }

                    Console.Out.WriteLine("\nThank you for using MYOB");
               }
               else
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
                    payslip.Print();
                    Console.WriteLine("\nThank you for using MYOB!");
               }
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
               this.CalculateTax(salary);

               // Calculate the super of the individual
               this.Super = Convert.ToInt32(this.GrossIncome * (superPercent / 100.0));

               // Calculates monthly net income
               this.NetIncome = this.GrossIncome - this.Tax;

          }

          public Payslip(string[] userData)
          {
               this.FullName = $"{userData[0]} {userData[1]}";
               int salary = Convert.ToInt32(userData[2]);
               
               // Calculate the tax
               this.CalculateTax(salary);
               
               // Calculates the monthly gross income
               this.GrossIncome = Math.Round((double) (salary / 12));

               // Removes the '%' character from the super, and converts it to an integer
               int superPercent = Convert.ToInt32(userData[3].Replace("%", ""));
               this.Super = Convert.ToInt32(this.GrossIncome * (superPercent / 100.0));
               
               // No need to reformat this
               this.PayPeriod = userData[4];
               
               this.NetIncome = this.GrossIncome - this.Tax;
          }
          private void CalculateTax(int salary)
          // Sets the property Tax to the correct tax value
          {
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
          }
          
          public void Print()
          {
               Console.WriteLine($"Name: {this.FullName}");
               Console.WriteLine($"Pay Period: {this.PayPeriod}");
               Console.WriteLine($"Gross Income: {this.GrossIncome}");
               Console.WriteLine($"Income Tax: {this.Tax}");
               Console.WriteLine($"Net Income: {this.NetIncome}");
               Console.WriteLine($"Super: {this.Super}");
          }

          
          //Properties
          public string FullName { get; set; }
          public string PayPeriod { get; set; }
          public double GrossIncome { get; set; }
          public double Tax { get; set; }
          public double NetIncome { get; set; }
          public double Super { get; set; }
     }

     public class CSV
     {
          // Properties
          public string FileName { get; set; }

          public CSV(string fileName)
          {
               this.FileName = fileName;
          }

          public List<Payslip> Read()
          {
               List<Payslip> payslips = new List<Payslip>();
               string[] lines = System.IO.File.ReadAllLines(this.FileName);
               for (int i = 1; i < lines.Length; i++)
               {
                    // Separates the line based on commas
                    string[] sep = lines[i].Split(",");
                    payslips.Add(new Payslip(sep));
               }

               return payslips;
          }
     }
}
