using OpenQA.Selenium;
using UserInterfaceTests.Pages.Locators;

namespace UserInterfaceTests.Pages
{
    internal class MainUserPage : MainUserPageLocators
    {
        private readonly IWebDriver webDriver;

        public MainUserPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        public DropDownCaretArea ClickDropDownCaret()
        {
            Awaiter.Wait(webDriver, dropDownCaret);
            webDriver.FindElement(dropDownCaret).Click();
            return new DropDownCaretArea(webDriver);
        }
    }
}
