using NUnit.Framework;
using OpenQA.Selenium;
using UserInterfaceTests.Pages;

namespace UserInterfaceTests
{
    [TestFixture]
    public class Tests : BaseUiTests
    {
        [Test]
        public void IsMainPage_MainPageTitleEqualsExpected_TrueReturned()
        {
            var expected = "GitHub: Where the world builds software · GitHub";
            var actual = GetTitle();

            Assert.AreEqual(expected, actual, "You don't found the main page.");
        }

        [Test]
        public void TryToSignIn_SuccessfulLogin_TrueReturned()
        {
            var indexPage = new IndexPage(webDriver);
            Assert.DoesNotThrow(() => { indexPage.ClickToSigInBtton().SignIn(); });
        }

        private string GetTitle()
        {
            Awaiter.Wait(webDriver, By.TagName("title"));
            return webDriver.Title;
        }
    }
}
