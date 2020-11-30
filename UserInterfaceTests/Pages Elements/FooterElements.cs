using OpenQA.Selenium;
using Tests.Core;

namespace UserInterfaceTests.Pages_Elements
{
    internal class FooterElements : BasePageElements
    {
        private readonly By dropDownCaret = By.XPath("//summary[@aria-label='View profile and more']");

        public IWebElement FindDropDownCaret()
        {
            webDriver.ScrollToTop();

            return webDriver.FindElement(dropDownCaret);
        }
    }
}
