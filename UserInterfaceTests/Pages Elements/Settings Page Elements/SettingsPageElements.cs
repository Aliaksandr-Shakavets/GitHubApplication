using OpenQA.Selenium;
using Tests.Core;

namespace UserInterfaceTests.Pages_Elements
{
    internal class SettingsPageElements : BasePageElements
    {
        private readonly By projectNamelocator = By.XPath("//strong[@itemprop='name']/a");

        public OptionsElements OptionsElements { get; } = new OptionsElements();

        public IWebElement GetProjectNameElement() => webDriver.GetVisibleElement(projectNamelocator);
    }
}
