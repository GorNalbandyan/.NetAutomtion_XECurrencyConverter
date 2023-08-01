using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace XECurrencyConverter.Pages
{
    public abstract class BasePage
    {
        public readonly WebDriverWait _wait;
        public readonly IWebDriver _driver;
        private TimeSpan _timeout = TimeSpan.FromSeconds(50.0);
        protected BasePage(IWebDriver driver) 
        {
            _driver = driver;
            _wait = new WebDriverWait(driver, _timeout)
            {
                PollingInterval = TimeSpan.FromMilliseconds(500.0)
            };
        }

        public void NavigateToPage(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }

        public IWebElement FindElement(By locator, IWebElement container = null, int timeout = 50)
        {
            try
            {
                IWebElement webElement = ((container != null)) ? container.FindElement(locator) : _driver.FindElement(locator);
                return webElement;
            }
            catch (NoSuchElementException)
            {
                return null;
            }
        }

        public void EnterText(By by, string textValue, int timeout = 50)
        {
            FindElement(by,null,timeout).SendKeys(textValue);
        }

        public void Click(By by, int timeout = 50)
        {
            IWebElement webElement = FindElement(by, null, timeout);
            try
            {
                webElement.Click();
            }
            catch(ElementClickInterceptedException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public bool IsDisplayed(By by, int timeout = 50)
        {
            try
            {
                _wait.Timeout = TimeSpan.FromSeconds(timeout);
                return _wait.Until(ExpectedConditions.ElementIsVisible(by)).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            catch (StaleElementReferenceException)
            {
                return false;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }

        public string GetText(By by, int timeout = 50)
        {
            _wait.Timeout = TimeSpan.FromSeconds(timeout);
            return _wait.Until(ExpectedConditions.ElementIsVisible(by)).Text;
        }

        public void WaitUntilVisible(By by, int timeout = 50)
        {
            _wait.Timeout = TimeSpan.FromSeconds(timeout);
            _wait.Until(ExpectedConditions.ElementIsVisible(by));
        }

        public void WaitUntilINVisible(By by, int timeout = 50)
        {
            _wait.Timeout = TimeSpan.FromSeconds(timeout);
            _wait.Until(ExpectedConditions.InvisibilityOfElementLocated(by));
        }
    }
}
