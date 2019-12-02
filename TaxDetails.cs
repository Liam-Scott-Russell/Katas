namespace Payslip_Round_2
{
    interface ITaxDetails
    {
        double GrossIncome { get; set; }
        double IncomeTax { get; set; }
        double NetIncome { get; set; }
    }
    public class TaxDetails : ITaxDetails
    {
        public double GrossIncome { get; set; }
        public double IncomeTax { get; set; }
        public double NetIncome { get; set; }
    }
}