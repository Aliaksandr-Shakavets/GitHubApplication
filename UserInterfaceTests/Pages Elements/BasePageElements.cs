using OpenQA.Selenium;
using Tests.Core;

namespace UserInterfaceTests.Pages_Elements
{
    internal abstract class BasePageElements
    {
        protected readonly IWebDriver webDriver = WebDriverSingleton.GetWebDriver();
    }
}
