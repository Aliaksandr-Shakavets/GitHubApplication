using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TestsFeatures;
using UserInterfaceTests.Pages;

namespace UserInterfaceTests
{
    public class BaseUiTests : ITests
    {
        private protected IWebDriver webDriver;
        private readonly Uri gitHubUri = new Uri(GitHubFeatures.Default.Url);
        private bool disposedValue;

        [OneTimeSetUp]
        public void RunBeforeAnyTests()
        {
            webDriver = new ChromeDriver();
            webDriver.Navigate().GoToUrl(gitHubUri);
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
            ScrollToTop();
            SignOut();
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

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

        private protected string GetTitle()
        {
            Awaiter.Wait(webDriver, By.TagName("title"));
            return webDriver.Title;
        }

        private void SignOut()
        {
            if (webDriver.Url != gitHubUri.ToString())
            {
                new MainUserPage(webDriver).ClickDropDownCaret().SignOut();
            }
        }

        private void ScrollToTop()
        {
            var jsExecutable = "window.scrollTo(0, 0);";
            (webDriver as IJavaScriptExecutor).ExecuteScript(jsExecutable);
        }
    }
}
