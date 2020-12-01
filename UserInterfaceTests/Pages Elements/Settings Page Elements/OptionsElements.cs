using OpenQA.Selenium;
using Tests.Core;

namespace UserInterfaceTests.Pages_Elements
{
    internal class OptionsElements : BasePageElements
    {
        protected readonly By deleteRepositoryButton = By.XPath("//summary[contains(text(),'Delete this repository')]");

        public IWebElement GetDeleteRepositoryButton()
        {
            webDriver.ScrollToBottom();

            return webDriver.GetVisibleElement(deleteRepositoryButton);
        }
    }
}
