using XECurrencyConverter.CurrencyList;
using XECurrencyConverter.Helpers;
using XECurrencyConverter.Pages;
using XECurrencyConverter.Steps;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace XECurrencyConverter.StepDefinitions
{
    [Binding]
    public class URLStepDefinitions : BaseSteps
    {
        private ScenarioContext _scenarioContext;
        public URLStepDefinitions(ScenarioContext scenarioContext,IWebDriver browser, Logger logger) : base(scenarioContext,browser,logger)
        { 
            _scenarioContext = scenarioContext;
        }

        [Then(@"Page URL is updated according to (.*) currencies")]
        public void ThenPageURLIsUpdatedAccordingToConversion(string conversionOrSwap)
        {
            string URL = new URLInteractions(_browser).GetConversionURL();
            switch (conversionOrSwap)
            {
                case "swapped":
                    Assert.IsTrue(URL.Contains($"Amount={_scenarioContext.Get<string>("amount")}" +
                        $"&From={CurrencyListWithAbbreviation.currencyAbbrDict[_scenarioContext.Get<string>("targetCurrency")]}" +
                        $"&To={CurrencyListWithAbbreviation.currencyAbbrDict[_scenarioContext.Get<string>("sourceCurrency")]}"),
                        "URL is not updated according to currencies and amount");
                    break;
                case "conversion":
                    Assert.IsTrue(URL.Contains($"Amount={_scenarioContext.Get<string>("amount")}" +
                        $"&From={CurrencyListWithAbbreviation.currencyAbbrDict[_scenarioContext.Get<string>("sourceCurrency")]}" +
                        $"&To={CurrencyListWithAbbreviation.currencyAbbrDict[_scenarioContext.Get<string>("targetCurrency")]}"), 
                        "URL is not updated according to currencies and amount");
                    break;
            }
        }

        [When(@"I use (.*) - (.*) to (.*) query params to apply conversion")]
        public void WhenIUsemQueryParamsToAccessConversion(string amount, string sourceCurrency, string targetCurrency)
        {
            new URLInteractions(_browser).MakeConversionViaURL(amount,sourceCurrency,targetCurrency);
        }
    }
}
