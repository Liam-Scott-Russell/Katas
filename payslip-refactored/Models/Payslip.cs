using System;

namespace Payslip_Round_2
{
    interface IPayslip
    {
        Employee Employee { get; set; }
        PayPeriod PayPeriod { get; set; }
        TaxDetails TaxInformation { get; set; }
    }
    public class Payslip : IPayslip
    {
        public Employee Employee { get; set; }
        public PayPeriod PayPeriod { get; set; }
        public TaxDetails TaxInformation { get; set; }
    }
}