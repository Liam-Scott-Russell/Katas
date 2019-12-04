using System;
using System.Dynamic;

namespace Payslip_Round_2
{
    public class TaxCalculator
    {
        private Employee _employee;
        
        public TaxCalculator(Employee employee)
        {
            _employee = employee;
        }

        private TaxBracket DetermineTaxBracket()
        {
            var country = _employee.Country;
            var salary = _employee.Salary;
            var correctTaxBracket = new TaxBracket();

            foreach (var bracket in country.TaxBrackets)
            {
                if (salary > bracket.LowerBound)
                {
                    correctTaxBracket = bracket;
                }
            }

            return correctTaxBracket;
        }
        
        public decimal GetGrossIncome()
        {
            var monthlySalary = _employee.Salary / 12;
            return CustomRound(monthlySalary);
        }

        public decimal GetIncomeTax()
        {
            var taxBracket = DetermineTaxBracket();
            
            var constantTax = taxBracket.ConstantTax;
            var taxWithinBracket = _employee.Salary - taxBracket.LowerBound;
            var perDollarTax = taxWithinBracket * taxBracket.PerDollarTax;

            var totalTax = (constantTax + perDollarTax) / 12;
            return CustomRound(totalTax);
        }

        public decimal GetNetIncome()
        {
            var netIncome = GetGrossIncome() - GetIncomeTax();
            return CustomRound(netIncome);
        }

        public decimal GetSuperAmount()
        {
            var superPercentAsDecimal = _employee.SuperPercent / 100;
            var superAmount = GetGrossIncome() * superPercentAsDecimal;
            return CustomRound(superAmount);
        }

        private decimal CustomRound(decimal number)
        {
            var decimalComponent = number - Math.Floor(number);

            return decimalComponent < (decimal) 0.5 ? Math.Floor(number) : Math.Ceiling(number);
        }
    }
}