using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace UserInterfaceTests
{
    public class Tests
    {
        private IWebDriver webDriver;

        [OneTimeSetUp]
        public void RunBeforeAnyTest()
        {
            webDriver = new ChromeDriver();
            webDriver.Manage().Window.Maximize();
        }

        [OneTimeTearDown]
        public void RunAfterAnyTests()
        {
            webDriver.Close();
        }
    }
}
