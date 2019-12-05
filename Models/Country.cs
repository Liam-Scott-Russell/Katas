using System.Collections.Generic;

namespace Payslip_Round_2
{
    interface ICountry
    {
        string CountryName { get; set; }
        List<TaxBracket> TaxBrackets { get; set; }
        string CurrencySymbol { get; set; }
    }
    public class Country : ICountry
    {
        public string CountryName { get; set; }
        public List<TaxBracket> TaxBrackets { get; set; }
        public string CurrencySymbol { get; set; }
    }
}