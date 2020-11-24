using OpenQA.Selenium;
using Tests.Core;

namespace UserInterfaceTests.Pages_Elements
{
    internal class IndexPageElements : BasePageElements
    {
        private readonly By signInButtonLocator = By.XPath("//a[@href='/login']");

        public IWebElement GetSignInButton() => webDriver.GetVisibleElement(signInButtonLocator);
    }
}
