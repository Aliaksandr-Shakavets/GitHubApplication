using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Tests.Core
{
    public static class WebDriverExtensions
    {
        public static IWebElement GetVisibleElement(this IWebDriver webDriver, By locator)
        {
            if (webDriver is null)
            {
                throw new System.ArgumentNullException(nameof(webDriver));
            }

            if (locator is null)
            {
                throw new System.ArgumentNullException(nameof(locator));
            }

            Wait(webDriver, locator);

            return webDriver.FindElement(locator);
        }

        public static IWebDriver ScrollToTop(this IWebDriver webDriver) => ScrollTo(webDriver, Direction.ToTop);

        public static IWebDriver ScrollToBottom(this IWebDriver webDriver) => ScrollTo(webDriver, Direction.ToBottom);

        public static IWebDriver ScrollToLetf(this IWebDriver webDriver) => ScrollTo(webDriver, Direction.ToLeft);

        public static IWebDriver ScrollToRight(this IWebDriver webDriver) => ScrollTo(webDriver, Direction.ToRight);

        private static IWebDriver ScrollTo(IWebDriver webDriver, Direction direction)
        {
            if (webDriver is null)
            {
                throw new System.ArgumentNullException(nameof(webDriver));
            }

            var jsExecutable = direction switch
            {
                Direction.ToTop => "window.scrollTo(0, 0);",
                Direction.ToBottom => "window.scrollTo(0, document.body.scrollHeight);",
                Direction.ToLeft => "arguments[0].scrollLeft = arguments[0].offsetWidth",
                Direction.ToRight => "arguments[0].scrollRight = arguments[0].offsetWidth",
                _ => throw new System.ArgumentException($"{nameof(direction)} not found", nameof(direction)),
            };

            (webDriver as IJavaScriptExecutor).ExecuteScript(jsExecutable);

            return webDriver;
        }

        private static void Wait(IWebDriver webDriver, By locator)
        {
            var timeOutFromSeconds = System.TimeSpan.FromSeconds(15);
            var webDriverAwaiter = new WebDriverWait(webDriver, timeOutFromSeconds);
            webDriverAwaiter.Until((w) => w.FindElement(locator));
        }
    }
}
