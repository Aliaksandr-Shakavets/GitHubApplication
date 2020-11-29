using NUnit.Framework;
using OpenQA.Selenium;
using Tests.Core;
using UserInterfaceTests.Pages;

namespace UserInterfaceTests
{
    public class BaseUiTests : ITests
    {
        private protected readonly IWebDriver webDriver = WebDriverSingleton.GetWebDriver();
        private bool disposedValue;

        [OneTimeSetUp]

        public void RunBeforeAnyTests()
        {
            webDriver.Navigate().GoToUrl(AppSettings.Url);
            webDriver.Manage().Window.Maximize();
        }

        [OneTimeTearDown]
        public void RunAfterAnyTests()
        {
            webDriver.Close();
            Dispose();
        }

        [SetUp]
        public void RunBeforeEachTest()
        {
            webDriver.Manage().Cookies.DeleteAllCookies();
        }

        [TearDown]
        public void RunAfterEachTest()
        {
            SignOut();
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            System.GC.SuppressFinalize(this);
        }

        public void SignOut() => new Footer().DropDownCaretClick().SignOut();

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    webDriver.Dispose();
                }

                disposedValue = true;
            }
        }
    }
}
