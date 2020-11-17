using OpenQA.Selenium;
using TestsFeatures;
using UserInterfaceTests.Pages.Locators;

namespace UserInterfaceTests.Pages
{
    internal class AuthPage : AuthPageLocators
    {
        private readonly IWebDriver webDriver;

        public AuthPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        public MainUserPage SignIn()
        {
            EnterTheLoggin();
            EnterThePassword();
            Submit();
            return new MainUserPage(webDriver);
        }

        private void Submit()
        {
            Awaiter.Wait(webDriver, submitButton);
            webDriver.FindElement(submitButton).Click();
        }

        private void EnterThePassword()
        {
            Awaiter.Wait(webDriver, userPasswordLocator);
            webDriver.FindElement(userPasswordLocator).SendKeys(GitHubFeatures.Default.Password);
        }

        private void EnterTheLoggin()
        {
            Awaiter.Wait(webDriver, userNameLocator);
            webDriver.FindElement(userNameLocator).SendKeys(GitHubFeatures.Default.Login);
        }
    }
}
