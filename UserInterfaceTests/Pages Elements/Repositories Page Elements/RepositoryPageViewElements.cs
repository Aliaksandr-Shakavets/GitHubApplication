using OpenQA.Selenium;
using Tests.Core;

namespace UserInterfaceTests.Pages_Elements
{
    internal class RepositoryPageViewElements : BasePageElements
    {
        private protected readonly By settingsButton = By.XPath("//a[@data-tab-item='settings-tab']");

        public IWebElement GetSettingsButton() => webDriver.GetVisibleElement(settingsButton);
    }
}
