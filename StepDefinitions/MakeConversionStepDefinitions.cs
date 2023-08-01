using XECurrencyConverter.Helpers;
using XECurrencyConverter.Pages;
using XECurrencyConverter.Steps;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace XECurrencyConverter.StepDefinitions
{
    [Binding]
    public class MakeConversionStepDefinitions : BaseSteps
    {
        private ScenarioContext _scenarioContext;
        public MakeConversionStepDefinitions(ScenarioContext scenarioContext, IWebDriver browser, Logger logger) : base(scenarioContext, browser, logger)
        {
            _scenarioContext = scenarioContext;
        }

        [When(@"I convert (.*) - (.*) to (.*)")]
        public void WhenIConvertSourceToTargetCurrency(string amount, string sourceCurrency, string targetCurrency)
        {
            _scenarioContext.Set(amount, "amount");
            _scenarioContext.Set(sourceCurrency, "sourceCurrency");
            _scenarioContext.Set(targetCurrency, "targetCurrency");
            _logger.Info($"Converting {amount} amount of {sourceCurrency} to {targetCurrency}");
            new CurrencyConverterPage(_browser).MakeConversion(amount, sourceCurrency, targetCurrency);
        }

        [When(@"I swap currencies")]
        public void WhenISwapCurrencies()
        {
            new CurrencyConverterPage(_browser).SwapCurrencies();
        }

        [Then(@"The curreincies are swapped")]
        public void ThenTheCurreinciesAreSwapped()
        {
            string sourceCurrency = new CurrencyConverterPage(_browser).GetFromCurrency();
            string targetCurrency = new CurrencyConverterPage(_browser).GetToCurrency();

            Assert.Multiple(()=>
            {
                Assert.IsTrue(sourceCurrency.Contains(_scenarioContext.
                    Get<string>("targetCurrency")), "Source and target currencies are not swaped");
                Assert.IsTrue(targetCurrency.Contains(_scenarioContext.
                    Get<string>("sourceCurrency")), "Target and source currencies are not swaped");
            });
        }

        [Given(@"Any conversion is done")]
        public void GivenAnyConversionIsDone()
        {
            new CurrencyConverterPage(_browser).Convert();
        }
    }
}
