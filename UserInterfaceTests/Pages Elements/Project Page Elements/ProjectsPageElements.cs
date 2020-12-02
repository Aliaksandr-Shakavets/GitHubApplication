using System;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using Tests.Core;

namespace UserInterfaceTests.Pages_Elements
{
    internal class ProjectsPageElements : BasePageElements
    {
        private protected readonly By newProjectButtom = By.XPath("//a[contains(@class,'btn') and contains(@href,'/new/project')]");
        private protected readonly By existProjectLocator = By.XPath("//h4[@class='mb-1']/a");
        private protected readonly string projectMenuStringLocator = "//div[@data-filter-value='projectName']/details/summary[@aria-label='Project menu']";
        private protected readonly By closeButton = By.XPath("//button[@value='closed']");
        private protected readonly By closedProjectsButton = By.XPath("//div[@class='table-list-header-toggle states']/a[contains(@href,'closed')]");

        internal IWebElement GetNewProjectButtom() => webDriver.GetVisibleElement(newProjectButtom);

        internal ReadOnlyCollection<IWebElement> GetProjects() => webDriver.GetVisibleElements(existProjectLocator);

        internal IWebElement GetProjectMenu(string projectName)
        {
            var projectMenuLocator = By.XPath(projectMenuStringLocator.Replace("projectName", projectName));

            return webDriver.GetVisibleElement(projectMenuLocator);
        }

        internal IWebElement GetClosedProjectsButton() => webDriver.GetVisibleElement(closedProjectsButton);

        internal IWebElement GetCloseButton() => webDriver.GetVisibleElement(closeButton);
    }
}
