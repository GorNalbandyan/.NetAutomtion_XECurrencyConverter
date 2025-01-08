using XECurrencyConverter.CurrencyList;
using OpenQA.Selenium;

namespace XECurrencyConverter.Pages
{
    internal class ConversionResultsPage : BasePage
    {
        private readonly By convertedFullAmount = By.XPath("//p[@class = 'sc-b5d1d4ba-1 bPeOTN']");
        private readonly By fromSourceToTarget = By.XPath("//*[@class = 'sc-98b4ec47-0 jnAVFH']/p[1]");
        private readonly By fromTargetToSource = By.XPath("//*[@class = 'sc-98b4ec47-0 jnAVFH']/p[2]");

        public ConversionResultsPage(IWebDriver driver) : base(driver)
        {
        }

        public string GetConvertedFullAmountText()
        {
            return GetText(convertedFullAmount);
        }

        public Tuple<string, string> GetConvertedFullAndSingleUnitAmountText()
        {
            string fromSourceToTargetText = GetText(fromSourceToTarget);
            string fromTargetToSourceText = GetText(fromTargetToSource);
            return Tuple.Create(fromSourceToTargetText, fromTargetToSourceText);
        }

        public double GetConvertedFullAmount(string targetCurrency)
        {
            string fullAmountText = GetConvertedFullAmountText();
            double fullAmount = double.Parse(fullAmountText.Split($"{targetCurrency}")[0]);
            return fullAmount;
        }

        public double GetConvertedUnitAmount(string sourceCurrency, string targetCurrency)
        {
            double fullAmount = double.Parse(GetConvertedFullAndSingleUnitAmountText().Item1.Replace(CurrencyListWithAbbreviation.currencyAbbrDict[targetCurrency], "").
                Replace($"1 {CurrencyListWithAbbreviation.currencyAbbrDict[sourceCurrency]} = ", "").Trim());
            return fullAmount;
        }
    }
}
