using System;

namespace Payslip_Round_2
{
    interface IPayPeriod
    {
        DateTime Start { get; set; }
        DateTime End { get; set; }
    }
    public class PayPeriod
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}