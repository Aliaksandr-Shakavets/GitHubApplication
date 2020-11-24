using Tests.Core;
using UserInterfaceTests.Pages;

namespace UserInterfaceTests.Logic_steps
{
    internal static class AuthenticationSteps
    {
        public static UserProfilePage Invoke()
        {
            var authPage = new IndexPage().SigInButtonClick();
            authPage.EnterLogin(AppSettings.Login);
            authPage.EnterPassword(AppSettings.Password);

            return authPage.Submit();
        }
    }
}
