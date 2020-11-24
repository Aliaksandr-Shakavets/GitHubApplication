using OpenQA.Selenium;
using Tests.Core;

namespace UserInterfaceTests.Pages_Elements
{
    internal class ProjectsPageElements : BasePageElements
    {
        private protected readonly By newProjectButtom = By.XPath("//a[contains(@class,'btn') and contains(@href,'/new/project')]");

        public IWebElement GetNewProjectButtom() => webDriver.GetVisibleElement(newProjectButtom);
    }
}
