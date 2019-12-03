namespace Payslip_Round_2
{
    interface ICountry
    {
        string CountryName { get; set; }
        TaxBracket[] TaxBrackets { get; set; }
        string CurrencySymbol { get; set; }
    }
    public class Country : ICountry
    {
        public string CountryName { get; set; }
        public TaxBracket[] TaxBrackets { get; set; }
        public string CurrencySymbol { get; set; }
    }
}