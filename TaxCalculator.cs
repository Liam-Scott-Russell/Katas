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

        public decimal GetGrossIncome()
        {
            var monthlySalary = _employee.Salary / 12;
            return CustomRound(monthlySalary);
        }

        public decimal GetIncomeTax()
        {
            var taxBracket = _employee.Country.DetermineTaxBracket(_employee.Salary);
            
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

        public decimal GetSuper()
        {
            var superPercentAsDecimal = _employee.SuperPercent / 100;
            var superAmount = GetGrossIncome() * superPercentAsDecimal;
            return CustomRound(superAmount);
        }

        private decimal CustomRound(decimal number)
        {
            return number;
        }
    }
}