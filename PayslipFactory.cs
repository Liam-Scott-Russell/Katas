namespace Payslip_Round_2
{
    public class PayslipFactory
    {
        public static Payslip MakePayslip(Employee employee, PayPeriod payPeriod)
        {
            return new Payslip()
            {
                Employee = employee,
                PayPeriod = payPeriod,
                TaxInformation = new TaxDetails()
            };
        }
        
        public static Payslip MakePayslip(string csvFileName)
        {
            return new Payslip();
        }
    }
}