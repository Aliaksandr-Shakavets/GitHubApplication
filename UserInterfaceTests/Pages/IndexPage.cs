using OpenQA.Selenium;
using UserInterfaceTests.Pages.Locators;

namespace UserInterfaceTests.Pages
{
    internal class IndexPage : IndexPageLocators
    {
        private readonly IWebDriver webDriver;

        public IndexPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        public AuthPage ClickToSigInBtton()
        {
            Awaiter.Wait(webDriver, signInButtonLocator);
            webDriver.FindElement(signInButtonLocator).Click();
            return new AuthPage(webDriver);
        }
    }
}
