using System.Collections.Generic;

namespace Payslip_Round_2
{
    public class Config
    {
        public static Country Australia { get; set; }= new Country()
        {
            CountryName = "Australia",
            CurrencySymbol = "$",
            TaxBrackets = new List<TaxBracket>()
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

        public static string CsvDelimiter { get; set; } = ",";

        public static string DateInputFormat { get; } = "dd MMMM";
        public static string DateOutputFormat { get; } = "dd MMMM";

    }
}