using XECurrencyConverter.Helpers;
using XECurrencyConverter.Pages;
using XECurrencyConverter.Steps;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace XECurrencyConverter.StepDefinitions
{
    [Binding]
    public class NavigationStepDefinitions : BaseSteps
    {
        public NavigationStepDefinitions(ScenarioContext scenarioContext, IWebDriver browser, Logger logger) : base(scenarioContext, browser,logger)
        { 
        }

        [Given(@"XE website is open")]
        public void GivenXEWebsiteIsOpen()
        {
            new NavigationPage(_browser).NavigateToXEWebsite();
        }

        [Given(@"I am on the (.*) screen")]
        public void GivenIAmOnTheXECurrencyConverterScreen(string screenName)
        {
            new NavigationPage(_browser).NavigateToScreen(screenName);
        }
    }
}
