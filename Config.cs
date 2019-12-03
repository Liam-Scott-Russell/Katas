namespace Payslip_Round_2
{
    public class Config
    {
        public static Country Australia { get; set; }= new Country()
        {
            CountryName = "Australia",
            CurrencySymbol = "$",
            TaxBrackets = new TaxBracket[5]
            {
                new TaxBracket()
                {
                    ConstantTax = 0,
                    LowerBound = 0,
                    UpperBound = 18200,
                    PerDollarTax = 0,
                },
                new TaxBracket()
                {
                    ConstantTax = 0,
                    LowerBound = 18200,
                    UpperBound = 37000,
                    PerDollarTax = (decimal) 0.19,
                },
                new TaxBracket()
                {
                    ConstantTax = 3572,
                    LowerBound = 37000,
                    UpperBound = 87000,
                    PerDollarTax = (decimal) 0.325,
                },
                new TaxBracket()
                {
                    ConstantTax = 19822,
                    LowerBound = 87000,
                    UpperBound = 180000,
                    PerDollarTax = (decimal) 0.37,
                },
                new TaxBracket()
                {
                    ConstantTax = 54232,
                    LowerBound = 180000,
                    UpperBound = decimal.MaxValue,
                    PerDollarTax = (decimal) 0.45,
                }
            }
        };
    }
}