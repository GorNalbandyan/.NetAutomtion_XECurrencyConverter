using NUnit.Framework;
using OpenQA.Selenium;

namespace XECurrencyConverter.Pages
{
    internal class CurrencyConverterPage : BasePage
    {
        private readonly By convertBtn = By.XPath("//button[(text()= 'Convert')]");
        private readonly By amountInput = By.Id("amount");
        private readonly By sourceCurrencyField = By.XPath("(//input[@type='text'])[2]");
        private readonly By targetCurrencyField = By.XPath("(//input[@type='text'])[3]");
        private readonly By amountValidationMessage = By.CssSelector(".currency-converter__ErrorText-zieln1-2");
        private readonly By invertCurrencyBtn = By.XPath("//button[@aria-label = 'Swap currencies']");
        private readonly By fromCurrencyField = By.Id("midmarketFromCurrency");
        private readonly By toCurrencyField = By.Id("midmarketToCurrency");

        public CurrencyConverterPage(IWebDriver driver) : base(driver)
        {
        }

        public void MakeConversion(string amount, string sourceCurrency, string targetCurrency)
        {
            EnterAmount(amount);
            SelectSourceCurrency(sourceCurrency);
            SelectTargetCurrency(targetCurrency);
            Convert();
        }

        public void EnterAmount(string amount)
        {
            EnterText(amountInput, amount);
        }

        public void SelectSourceCurrency(string sourceCurrency)
        {
            Click(sourceCurrencyField);
            EnterText(sourceCurrencyField, sourceCurrency);
            Click(By.XPath($"//*[(contains(@class,'converterform-dropdown__option') or contains(@class,'ListboxOption')) and contains(.,'{sourceCurrency}')]"));
        }

        public void SelectTargetCurrency(string targetCurrency)
        {
            Click(targetCurrencyField);
            EnterText(targetCurrencyField, targetCurrency);
            Click(By.XPath($"//*[(contains(@class,'converterform-dropdown__option') or contains(@class,'ListboxOption')) and contains(.,'{targetCurrency}')]"));
        }

        public void Convert()
        {
            Click(convertBtn);
        }

        public string GetAmountValidationMessage()
        {
            if (IsDisplayed(amountValidationMessage,15))
            {
                return GetText(amountValidationMessage);
            }
            else
            {
                Assert.Fail("Amount validation message is not displayed");
                return null;
            }
        }

        public void SwapCurrencies()
        {
            Click(invertCurrencyBtn);
        }

        public string GetToCurrency()
        {
            return GetText(toCurrencyField);
        }

        public string GetFromCurrency()
        {
            return GetText(fromCurrencyField);
        }
    }
}
