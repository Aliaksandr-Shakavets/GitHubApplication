using UserInterfaceTests.Pages_Elements;

namespace UserInterfaceTests.Pages
{
    internal class IndexPage
    {
        private readonly IndexPageElements pageElements = new IndexPageElements();

        public AuthPage SigInButtonClick()
        {
            var signInButton = pageElements.GetSignInButton();
            signInButton.Click();

            return new AuthPage();
        }
    }
}
