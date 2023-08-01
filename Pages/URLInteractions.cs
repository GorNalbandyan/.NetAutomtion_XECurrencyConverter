using XECurrencyConverter.CurrencyList;
using XECurrencyConverter.Helpers;
using OpenQA.Selenium;

namespace XECurrencyConverter.Pages
{
    internal class URLInteractions : BasePage
    {
        private readonly By convertBtn = By.XPath("//button[(text()= 'Convert')]");
        public URLInteractions(IWebDriver driver) : base(driver)
        {
        }
        
        public string GetConversionURL()
        {
            WaitUntilINVisible(convertBtn);
            return _driver.Url;
        }

        public void MakeConversionViaURL(string amount, string sourceCurrency, string targetCurrency)
        {
            string URLwithQueryParams = new SettingsHelper().Url + $"?Amount={amount}&From={CurrencyListWithAbbreviation.currencyAbbrDict[sourceCurrency]}&" +
                $"To={CurrencyListWithAbbreviation.currencyAbbrDict[targetCurrency]}";
            _driver.Navigate().GoToUrl(URLwithQueryParams);
        }
    }
}
