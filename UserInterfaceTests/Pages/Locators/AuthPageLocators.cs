using OpenQA.Selenium;

namespace UserInterfaceTests.Pages.Locators
{
    internal class AuthPageLocators
    {
        private protected readonly By userNameLocator = By.XPath("//input[@id='login_field']");
        private protected readonly By userPasswordLocator = By.XPath("//input[@id='password']");
        private protected readonly By submitButton = By.XPath("//input[@name='commit']");
    }
}
