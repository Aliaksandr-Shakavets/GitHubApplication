using OpenQA.Selenium;

namespace UserInterfaceTests.Pages.Locators
{
    internal class IndexPageLocators
    {
        private protected readonly By signInButtonLocator = By.XPath("//a[@href='/login']");
    }
}
