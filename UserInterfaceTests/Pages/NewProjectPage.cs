using OpenQA.Selenium;

namespace UserInterfaceTests.Pages
{
    internal class NewProjectPage
    {
        private IWebDriver webDriver;

        public NewProjectPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }
    }
}