using NUnit.Framework;
using static XECurrencyConverter.Helpers.BrowserHelper;

namespace XECurrencyConverter.Helpers
{
    internal class SettingsHelper
    {
        public BrowserType Browser { get; set; }
        public string Url { get; set; }
        public SettingsHelper()
        {
            var browserName = GetSettings("Browser");
            _ = Enum.TryParse(browserName, out BrowserType browser);
            Browser = browser;
            Url = GetSettings("Url");
        }

        public static string? GetSettings(string settingName)
        {
            if (!TestContext.Parameters.Exists(settingName))
            {
                Assert.Fail($"{settingName} setting is missing");
            }
            return TestContext.Parameters.Get(settingName);
        }
    }
}
