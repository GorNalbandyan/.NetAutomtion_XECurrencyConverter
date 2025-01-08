using XECurrencyConverter.CurrencyList;
using XECurrencyConverter.Helpers;
using XECurrencyConverter.Pages;
using XECurrencyConverter.Steps;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using System.Linq;

namespace XECurrencyConverter.StepDefinitions
{
    [Binding]
    public class ConversionValidationStepDefinitions : BaseSteps
    {
        private ScenarioContext _scenarioContext;
        public ConversionValidationStepDefinitions(ScenarioContext scenarioContext,IWebDriver browser, Logger logger) : base(scenarioContext,browser,logger)
        { 
            _scenarioContext = scenarioContext;
        }

        [Then(@"Full conversion amount in (.*) is displayed")]
        public void ThenConvertedValueIsDisplayed(string targetCurrency)
        {
            Assert.IsTrue(new ConversionResultsPage(_browser).GetConvertedFullAmountText().Contains(targetCurrency), $"Converted value is not displayed in {targetCurrency} currency");
        }

        [Then(@"Single Unit conversion amount from (.*) to (.*) and vice versa is displayed")]
        public void ThenSingleUnitConversionAmountFromToIsDisplayed(string sourceCurrency, string targetCurrency)
        {
            var unitConversionAmountText = new ConversionResultsPage(_browser).GetConvertedFullAndSingleUnitAmountText();
            Assert.Multiple(() =>
            {
                Assert.IsTrue(unitConversionAmountText.Item1.Contains($"1 {CurrencyListWithAbbreviation.currencyAbbrDict[sourceCurrency]} = ") && unitConversionAmountText.
                    Item1.Contains($"{CurrencyListWithAbbreviation.currencyAbbrDict[targetCurrency]}"), "Single Unit amount is not correctly displayed");
                Assert.IsTrue(unitConversionAmountText.Item2.Contains($"1 {CurrencyListWithAbbreviation.currencyAbbrDict[targetCurrency]} = ") && unitConversionAmountText.
                    Item2.Contains($"{CurrencyListWithAbbreviation.currencyAbbrDict[sourceCurrency]}"), "Single Unit amount vice versa is not correctly displayed");
            });
        }

        [Then(@"Unit And Full conversion amounts are mathematically correct")]
        public void ThenUnitAndFullConversionAmountsAreMathematicallyCorrect()
        {
            double convertedFullAmount = new ConversionResultsPage(_browser).GetConvertedFullAmount(_scenarioContext.
                Get<string>("targetCurrency"));
            double convertedUnitAmount = new ConversionResultsPage(_browser).GetConvertedUnitAmount(_scenarioContext.
                Get<string>("sourceCurrency"), _scenarioContext.Get<string>("targetCurrency"));
            Assert.AreEqual(Math.Round(convertedFullAmount / double.Parse(_scenarioContext.
                Get<string>("amount")), 3), convertedUnitAmount, "Unit And Full conversion amounts are NOT mathematically correct");
        }

        [Then(@"Negative value validation message shoud appear")]
        public void ThenNegativeValueValidationMessageShoudAppear()
        {
            string negativeValueValidationMessage = "Please enter an amount greater than 0";
            Assert.AreEqual(negativeValueValidationMessage, new CurrencyConverterPage(_browser)
                .GetAmountValidationMessage(), $"Negative value validation message is not displayed or is not correct");
        }

        [Then(@"Non numeric amount validation message shoud appear")]
        public void ThenNonNumericAmountValidationMessageShoudAppear()
        {
            string nonNumericValidationMessage = "Please enter a valid amount";
            Assert.AreEqual(nonNumericValidationMessage, new CurrencyConverterPage(_browser)
                .GetAmountValidationMessage(), $"Negative value validation message is not displayed or is not correct");
        }
    }
}
