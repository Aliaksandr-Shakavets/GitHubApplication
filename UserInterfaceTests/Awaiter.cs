using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace UserInterfaceTests
{
    internal static class Awaiter
    {
        private static TimeSpan timeOutFromSeconds = TimeSpan.FromSeconds(15);

        public static void Wait(IWebDriver webDriver, By locator)
        {
            var webDriverAwaiter = new WebDriverWait(webDriver, timeOutFromSeconds);
            webDriverAwaiter.Until((w) => w.FindElement(locator));
        }
    }
}
