using OpenQA.Selenium;
using Tests.Core;

namespace UserInterfaceTests.Pages_Elements
{
    internal class ProfileAreaMenuElements : BasePageElements
    {
        private readonly By profileButton = By.XPath("//details-menu[@class='dropdown-menu dropdown-menu-sw']/child::a[text()='Your profile']");
        private readonly By repositoriesButton = By.XPath("//details-menu[@class='dropdown-menu dropdown-menu-sw']/child::a[text()='Your repositories']");
        private readonly By projectsButton = By.XPath("//details-menu[@class='dropdown-menu dropdown-menu-sw']/child::a[text()='Your projects']");
        private readonly By signOutButton = By.XPath("//button[@type='submit' and contains(text(),'Sign out')]");

        public IWebElement GetProfileButton() => webDriver.GetVisibleElement(profileButton);

        public IWebElement GetRepositoriesButton() => webDriver.GetVisibleElement(repositoriesButton);

        public IWebElement GetProjectsButton() => webDriver.GetVisibleElement(projectsButton);

        public IWebElement GetSignOutButton() => webDriver.GetVisibleElement(signOutButton);
    }
}
