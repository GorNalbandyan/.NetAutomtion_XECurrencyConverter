using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XECurrencyConverter.CurrencyList
{
    public static class CurrencyListWithAbbreviation
    {
        public static Dictionary<string, string> currencyAbbrDict = new Dictionary<string, string>()
        {
            {"British Pound", "GBP" },
            {"US Dollar", "USD" },
            {"Indian Rupee", "INR" },
            {"Armenian Dram", "AMD" },
            {"Swiss Franc", "CHF" }
        };

    }
}
