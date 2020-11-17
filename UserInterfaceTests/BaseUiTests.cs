using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TestsFeatures;

namespace UserInterfaceTests
{
    public class BaseUiTests : ITests
    {
        private protected IWebDriver webDriver;
        private bool disposedValue;

        [OneTimeSetUp]
        public void RunBeforeAnyTests()
        {
            webDriver = new ChromeDriver();
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
            var uri = new Uri(GitHubFeatures.Default.Url);
            webDriver.Navigate().GoToUrl(uri);
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
    }
}
