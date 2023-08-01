using XECurrencyConverter.Helpers;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace XECurrencyConverter.Steps
{
    public class BaseSteps : TechTalk.SpecFlow.Steps
    {
        public readonly IWebDriver _browser;
        public readonly Logger _logger;
        public ScenarioContext _scenarioContext;

        public BaseSteps(ScenarioContext scenarioContext, IWebDriver browser, Logger logger)
        {
            _browser = browser;
            _logger = logger;
            _scenarioContext = scenarioContext;
        }
    }
}