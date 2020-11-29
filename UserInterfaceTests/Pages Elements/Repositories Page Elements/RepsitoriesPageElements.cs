using OpenQA.Selenium;
using Tests.Core;

namespace UserInterfaceTests.Pages_Elements
{
    internal class RepsitoriesPageElements : BasePageElements
    {
        private protected readonly By newRepositoryLocator = By.XPath("//a[@href='/new' and contains(@class,'btn-primary')]");
        private protected readonly By existRepositoryLocator = By.XPath("//a[@itemprop='name codeRepository']");

        public IWebElement GetNewRepositoryButton() => webDriver.GetVisibleElement(newRepositoryLocator);

        public IWebElement GetExistRepository() => webDriver.GetVisibleElement(existRepositoryLocator);
    }
}
