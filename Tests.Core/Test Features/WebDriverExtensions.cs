using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using Tests.Core.Services;

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

        public static IWebDriver ClickToUnclicableElement(this IWebDriver webDriver, IWebElement element)
        {
            new Actions(webDriver).MoveToElement(element).Click().Build().Perform();

            return webDriver;
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
            
            _ = direction switch
            {
                Direction.ToTop => JavaScriptExecutorService.Execute("window.scrollTo(0, 0);"),
                Direction.ToBottom => JavaScriptExecutorService.Execute("window.scrollTo(0, document.body.scrollHeight);"),
                Direction.ToLeft => JavaScriptExecutorService.Execute("arguments[0].scrollLeft = arguments[0].offsetWidth"),
                Direction.ToRight => JavaScriptExecutorService.Execute("arguments[0].scrollRight = arguments[0].offsetWidth"),
                _ => throw new System.NotImplementedException(),
            };

            return webDriver;
        }

        private static void Wait(IWebDriver webDriver, By locator)
        {
            var timeOutFromSeconds = System.TimeSpan.FromSeconds(10);
            var webDriverAwaiter = new WebDriverWait(webDriver, timeOutFromSeconds);
            webDriverAwaiter.Until((w) => w.FindElement(locator));
        }
    }
}
