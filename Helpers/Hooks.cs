using BoDi;
using XECurrencyConverter.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using static XECurrencyConverter.Helpers.BrowserHelper;

namespace XECurrencyConverter.Helpers
{
    [Binding]
    internal class Hooks
    {
        public static BrowserType browser;
        private readonly IObjectContainer objectContainer;
        IWebDriver webDriver;

        public Hooks(IObjectContainer objectContainer)
        {
            this.objectContainer = objectContainer;
        }

        [BeforeScenario]
        public void StartBrowser(ScenarioContext scenarioContext)
        {
            var logger = new Logger(TestContext.CurrentContext.Test.FullName);
            webDriver = new BrowserHelper(logger).LoadBrowser(new SettingsHelper().Browser);
            objectContainer.RegisterInstanceAs<Logger>(logger);
            objectContainer.RegisterInstanceAs<IWebDriver>(webDriver);
            SettingsHelper settings = objectContainer.Resolve<SettingsHelper>();
            scenarioContext.Set(settings);
            scenarioContext.Set(logger);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            Logger logger = objectContainer.Resolve<Logger>();
            IWebDriver webDriver = objectContainer.Resolve<IWebDriver>();
            var screenshot = Path.Combine(logger.FilePath, "Screenshot.png");
            Screenshot testScreenShot = ((ITakesScreenshot)webDriver).GetScreenshot();
            testScreenShot.SaveAsFile(screenshot, ScreenshotImageFormat.Png);
            foreach (var file in Directory.GetFiles(logger.FilePath))
            {
                TestContext.AddTestAttachment(file);
            }
            webDriver.Dispose();
            webDriver.Quit();
        }
    }
}
