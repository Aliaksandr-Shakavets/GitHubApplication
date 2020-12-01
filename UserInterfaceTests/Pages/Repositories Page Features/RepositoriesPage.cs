using System.Linq;
using Tests.Core.Data_access_layer;
using UserInterfaceTests.Pages_Elements;

namespace UserInterfaceTests.Pages
{
    internal class RepositoriesPage : Footer
    {
        private readonly RepsitoriesPageElements pageElements = new RepsitoriesPageElements();

        public RepositoryFormPage GetRepositoryFormPage(RepositoryFormInfo repositoryForm)
        {
            var newRepositoryButton = pageElements.GetNewRepositoryButton();
            newRepositoryButton.Click();

            return new RepositoryFormPage(repositoryForm);
        }

        public RepositoryPageView GetExistsRepositoryPage()
        {
            var existRepositoryPage = pageElements.GetExistRepository();
            existRepositoryPage.Click();

            return new RepositoryPageView();
        }

        public bool ContainsRepository(string repositoryName)
        {
            var existsRepositories = pageElements.GetRepositories();

            return existsRepositories.Any(r => r.Text == repositoryName);
        }
    }
}