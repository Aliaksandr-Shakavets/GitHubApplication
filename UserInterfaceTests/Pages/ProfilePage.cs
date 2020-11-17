using OpenQA.Selenium;
using UserInterfaceTests.Pages.Locators;

namespace UserInterfaceTests.Pages
{
    internal class ProfilePage : ProfilePageLocators
    {
        private readonly IWebDriver webDriver;

        public ProfilePage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }
    }
}