namespace Payslip_Round_2
{
    public class PayslipFactory
    {
        public static Payslip MakePayslip(Employee employee)
        {
            return new Payslip();
        }
        
        public static Payslip MakePayslip(string csvFileName)
        {
            return new Payslip();
        }
    }
}