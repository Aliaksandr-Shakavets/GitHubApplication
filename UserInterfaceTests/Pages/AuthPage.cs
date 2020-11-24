using UserInterfaceTests.Pages_Elements;

namespace UserInterfaceTests.Pages
{
    internal class AuthPage
    {
        private readonly AuthPageElements pageElements = new AuthPageElements();

        public AuthPage EnterPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                throw new System.ArgumentException($"'{nameof(password)}' cannot be null or empty", nameof(password));
            }

            const int minPasswordLength = 8;

            if (password.Length < minPasswordLength)
            {
                throw new System.ArgumentException($"'{nameof(password)}' length cannot be less than 8 characters", nameof(password));
            }

            pageElements.GetPasswordInput().SendKeys(password);

            return this;
        }

        public AuthPage EnterLogin(string login)
        {
            if (string.IsNullOrEmpty(login))
            {
                throw new System.ArgumentException($"'{nameof(login)}' cannot be null or empty", nameof(login));
            }

            pageElements.GetLoginInput().SendKeys(login);

            return this;
        }

        public UserProfilePage Submit()
        {
            pageElements.GetSubmitButton().Click();

            return new UserProfilePage();
        }
    }
}
