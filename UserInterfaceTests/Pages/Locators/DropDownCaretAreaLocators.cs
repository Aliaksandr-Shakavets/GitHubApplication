using OpenQA.Selenium;

namespace UserInterfaceTests.Pages.Locators
{
    internal class DropDownCaretAreaLocators
    {
        private protected readonly By yourProfile = By.XPath("//details-menu[@class='dropdown-menu dropdown-menu-sw']/child::a[text()='Your profile']");
        private protected readonly By yourRepositories = By.XPath("//details-menu[@class='dropdown-menu dropdown-menu-sw']/child::a[text()='Your repositories']");
        private protected readonly By yourProjects = By.XPath("//details-menu[@class='dropdown-menu dropdown-menu-sw']/child::a[text()='Your projects']");
    }
}
