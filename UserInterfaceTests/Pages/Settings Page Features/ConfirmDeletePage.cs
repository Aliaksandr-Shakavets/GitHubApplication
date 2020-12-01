using Tests.Core;
using UserInterfaceTests.Pages_Elements;

namespace UserInterfaceTests.Pages
{
    internal class ConfirmDeletePage
    {
        private readonly ConfirmDeletePageElements pageElements = new ConfirmDeletePageElements();
        private readonly string verifyInput;

        public ConfirmDeletePage(string verifyInput)
        {
            if (string.IsNullOrEmpty(verifyInput))
            {
                throw new System.ArgumentException($"'{nameof(verifyInput)}' cannot be null or empty", nameof(verifyInput));
            }

            this.verifyInput = AppSettings.Login + "/" + verifyInput;
        }

        public ConfirmDeletePage SetVerify()
        {
            var input = pageElements.GetInpetType();
            input.SendKeys(verifyInput);

            return this;
        }

        public RepositoriesPage Submit()
        {
            var button = pageElements.GetConfirmButton();
            button.Click();

            return new RepositoriesPage();
        }
    }
}
