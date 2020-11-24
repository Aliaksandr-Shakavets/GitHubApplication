using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Opera;

namespace Tests.Core
{
    public static class WebDriverSingleton
    {
        private static IWebDriver @this;

        public static IWebDriver GetWebDriver()
        {
            return @this ?? GetWebDriverInstance(AppSettings.BrowserType);
        }

        private static IWebDriver GetWebDriverInstance(string browserType)
        {
            switch (browserType.ToUpperInvariant())
            {
                case "CHROME":
                    {
                        @this = new ChromeDriver();
                        break;
                    }

                case "FIREFOX":
                    {
                        @this = new FirefoxDriver();
                        break;
                    }

                case "OPERA":
                    {
                        @this = new OperaDriver();
                        break;
                    }

                default:
                    throw new System.ArgumentException($"{browserType} is not supported.");
            }

            return @this;
        }
    }
}
