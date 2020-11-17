using OpenQA.Selenium;
using UserInterfaceTests.Pages.Locators;

namespace UserInterfaceTests.Pages
{
    internal class ProjectsPage : ProjectsPageLocators
    {
        private readonly IWebDriver webDriver;

        public ProjectsPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        public NewProjectPage CreateNewProject()
        {
            Awaiter.Wait(webDriver, newProjectLocator);
            webDriver.FindElement(newProjectLocator).Click();
            return new NewProjectPage(webDriver);
        }
    }
}