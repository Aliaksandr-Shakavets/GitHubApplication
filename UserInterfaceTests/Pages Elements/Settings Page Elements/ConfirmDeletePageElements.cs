using System.Linq;
using OpenQA.Selenium;
using Tests.Core;

namespace UserInterfaceTests.Pages_Elements
{
    internal class ConfirmDeletePageElements : BasePageElements
    {
        private readonly By inputType = By.XPath("//form[@method='post']/p/input");
        private readonly By confirmButton = By.XPath("//button[@type='submit']");

        public IWebElement GetInpetType() => webDriver.GetVisibleElements(inputType).Last();

        public IWebElement GetConfirmButton() => webDriver.GetVisibleElements(confirmButton).Last();
    }
}
