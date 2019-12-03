namespace Payslip_Round_2
{
    interface ITaxDetails
    {
        decimal GrossIncome { get; set; }
        decimal IncomeTax { get; set; }
        decimal NetIncome { get; set; }
        decimal Super { get; set; }
    }
    public class TaxDetails : ITaxDetails
    {
        public decimal GrossIncome { get; set; }
        public decimal IncomeTax { get; set; }
        public decimal NetIncome { get; set; }
        public decimal Super { get; set; }
    }
}