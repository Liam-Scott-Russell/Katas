namespace Payslip_Round_2
{
    public class PayslipFactory
    {
        public static Payslip MakePayslip(Employee employee, PayPeriod payPeriod)
        {
            var calculator = new TaxCalculator(employee);
            return new Payslip()
            {
                Employee = employee,
                PayPeriod = payPeriod,
                TaxInformation = new TaxDetails()
                {
                    GrossIncome = calculator.GetGrossIncome(),
                    IncomeTax = calculator.GetIncomeTax(),
                    NetIncome = calculator.GetNetIncome(),
                    Super = calculator.GetSuper()
                }
            };
        }
        
        public static Payslip MakePayslip(string csvFileName)
        {
            return new Payslip();
        }
    }
}