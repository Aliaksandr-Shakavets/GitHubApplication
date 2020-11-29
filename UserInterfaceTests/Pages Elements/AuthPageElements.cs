using OpenQA.Selenium;
using Tests.Core;

namespace UserInterfaceTests.Pages_Elements
{
    internal class AuthPageElements : BasePageElements
    {
        private readonly By incorrectUserValuesLocator = By.XPath("//*[@id='js-flash-container']");
        private readonly By userLoginName = By.XPath("//input[@id='login_field']");
        private readonly By userPasswordLocator = By.XPath("//input[@id='password']");
        private readonly By submitButton = By.XPath("//input[@name='commit']");

        public IWebElement FindSignInErrorMessage() => webDriver.FindElement(incorrectUserValuesLocator);

        public IWebElement GetPasswordInput() => webDriver.GetVisibleElement(userPasswordLocator);

        public IWebElement GetLoginInput() => webDriver.GetVisibleElement(userLoginName);

        public IWebElement GetSubmitButton() => webDriver.GetVisibleElement(submitButton);
    }
}
