using XECurrencyConverter.Helpers;
using OpenQA.Selenium;

namespace XECurrencyConverter.Pages
{
    internal class NavigationPage : BasePage
    {
        private readonly By registerBtn = By.XPath("//span[(text()= 'Register')]");

        public NavigationPage(IWebDriver driver) : base(driver)
        {
        }
        public void NavigateToXEWebsite()
        {
            NavigateToPage(new SettingsHelper().Url);
            WaitUntilVisible(registerBtn);
        }

        public void NavigateToScreen(string screenName)
        {
            Click(By.XPath($"//span[(text()= '{screenName}')]"));
        }
    }
}
