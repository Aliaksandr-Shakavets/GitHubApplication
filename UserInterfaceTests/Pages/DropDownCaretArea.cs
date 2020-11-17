using OpenQA.Selenium;
using UserInterfaceTests.Pages.Locators;

namespace UserInterfaceTests.Pages
{
    internal class DropDownCaretArea : DropDownCaretAreaLocators
    {
        private readonly IWebDriver webDriver;

        public DropDownCaretArea(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        public ProfilePage GoToProfilePage()
        {
            Awaiter.Wait(webDriver, yourProfile);
            webDriver.FindElement(yourProfile).Click();
            return new ProfilePage(webDriver);
        }

        public RepositoriesPage GoToRepositoriesPage()
        {
            Awaiter.Wait(webDriver, yourRepositories);
            webDriver.FindElement(yourRepositories).Click();
            return new RepositoriesPage(webDriver);
        }

        public ProjectsPage GoToProjectsPage()
        {
            Awaiter.Wait(webDriver, yourProjects);
            webDriver.FindElement(yourProjects).Click();
            return new ProjectsPage(webDriver);
        }

        public void SignOut()
        {
            Awaiter.Wait(webDriver, signOut);
            webDriver.FindElement(signOut).Click();
        }
    }
}