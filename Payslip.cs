using System;

namespace Payslip_Round_2
{
    interface IPayslip
    {
        Employee Employee { get; set; }
        DateTime PaymentStart { get; set; }
        DateTime PaymentEnd { get; set; }
        TaxDetails TaxInformation { get; set; }
    }
    public class Payslip : IPayslip
    {
        public Employee Employee { get; set; }
        public DateTime PaymentStart { get; set; }
        public DateTime PaymentEnd { get; set; }
        public TaxDetails TaxInformation { get; set; }
    }
}