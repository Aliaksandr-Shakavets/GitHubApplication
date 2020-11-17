using OpenQA.Selenium;

namespace UserInterfaceTests.Pages.Locators
{
    internal class ProjectsPageLocators
    {
        private protected readonly By newProjectLocator = By.XPath("//a[contains(@class,'btn') and contains(@href,'/new/project')]");
    }
}
