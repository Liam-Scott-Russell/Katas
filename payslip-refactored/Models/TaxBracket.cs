namespace Payslip_Round_2
{
    public interface ITaxBracket
    {
        decimal LowerBound { get; set; }
        decimal UpperBound { get; set; }
        decimal ConstantTax { get; set; }
        decimal PerDollarTax { get; set; }
    }
    public class TaxBracket : ITaxBracket
    {
        public decimal LowerBound { get; set; }
        public decimal UpperBound { get; set; }
        public decimal ConstantTax { get; set; }
        public decimal PerDollarTax { get; set; }
    }
}