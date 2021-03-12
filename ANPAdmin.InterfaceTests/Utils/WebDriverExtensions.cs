using OpenQA.Selenium;
using System;

namespace ANPAdmin.InterfaceTests.Utils
{
    public static class WebDriverExtensions
    {
        public static void LoadPage(this IWebDriver webDriver,
                    TimeSpan timeToWait, string url)
        {
            webDriver.Manage().Timeouts().PageLoad = timeToWait;
            webDriver.Navigate().GoToUrl(url);
        }

        public static string GetText(this IWebDriver webDriver, By by)
        {
            return webDriver.FindElement(by).Text;
        }

        public static void SetText(this IWebDriver webDriver, By by, string text)
        {
            webDriver.FindElement(by).SendKeys(text);
        }

        public static void Submit(this IWebDriver webDriver, By by)
        {
            webDriver.FindElement(by).Submit();
        }
    }
}
