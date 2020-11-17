using OpenQA.Selenium;

namespace UserInterfaceTests.Pages.Locators
{
    internal class RepsitoriesPageLocators
    {
        private protected readonly By newRepositoryLocator = By.XPath("//a[@href='/new' and contains(@class,'btn-primary')]");
    }
}
