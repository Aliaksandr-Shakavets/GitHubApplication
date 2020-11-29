using System;
using Tests.Core;
using UserInterfaceTests.Pages;

namespace UserInterfaceTests.Logic_steps
{
    internal static class AuthenticationSteps
    {
        public static UserProfilePage SignIn()
        {
            var authPage = new IndexPage().SigInButtonClick();

            authPage.EnterLogin(AppSettings.Login)
                    .EnterPassword(AppSettings.Password);

            var userProfilePage = authPage.Submit();
            CkeckForSuccessLogin(authPage);

            return userProfilePage;
        }

        private static void CkeckForSuccessLogin(AuthPage authPage)
        {
            if (!authPage.IsSigInSuccessful())
            {
                throw new ArgumentException("SignIn is failed: Incorrect username or password");
            }
        }
    }
}
