using UserInterfaceTests.Pages_Elements;

namespace UserInterfaceTests.Pages
{
    internal class RepositoriesPage : Footer
    {
        private readonly RepsitoriesPageElements pageElements = new RepsitoriesPageElements();

        public RepositoryFormPage ClickToNewRepository()
        {
            var newRepositoryButton = pageElements.GetNewRepositoryButton();
            newRepositoryButton.Click();

            return new RepositoryFormPage();
        }
    }
}