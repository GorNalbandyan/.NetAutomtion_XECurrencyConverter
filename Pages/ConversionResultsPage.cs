using XECurrencyConverter.CurrencyList;
using OpenQA.Selenium;

namespace XECurrencyConverter.Pages
{
    internal class ConversionResultsPage : BasePage
    {
        private readonly By convertedFullAmount = By.CssSelector(".result__BigRate-sc-1bsijpp-1");
        private readonly By convertedSingleUnitAmount = By.CssSelector(".unit-rates___StyledDiv-sc-1dk593y-0");

        public ConversionResultsPage(IWebDriver driver) : base(driver)
        {
        }

        public string GetConvertedFullAmountText()
        {
            return GetText(convertedFullAmount);
        }

        public Tuple<string, string> GetConvertedFullAndSingleUnitAmountText()
        {
            string conversionUnitAmountText = GetText(convertedSingleUnitAmount);
            string fromSourceToTargetText = conversionUnitAmountText.Split("\r\n")[0];
            string fromTargetToSourceText = conversionUnitAmountText.Split("\r\n").Last();
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
