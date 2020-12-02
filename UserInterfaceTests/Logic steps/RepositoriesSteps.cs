using Tests.Core.Data_access_layer;
using UserInterfaceTests.Pages;

namespace UserInterfaceTests.Logic_steps
{
    internal static class RepositoriesSteps
    {
        internal static RepositoryPageView CreateNewRepository(RepositoryFormInfo repositoryForm)
        {
            return GoToRepositorisePage()
                .GetRepositoryFormPage(repositoryForm)
                .SetName()
                .SetDescriptions()
                .SetVisibility()
                .AddReadmeRadioButton()
                .AddGitIgnore()
                .Submit();
        }

        internal static RepositoriesPage GoToRepositorisePage(bool needToSignIn = true)
        {
            if (needToSignIn)
            {
                return AuthenticationSteps.SignIn()
                                .DropDownCaretClick()
                                .GoToRepositoriesPage();
            }

            return new Footer().DropDownCaretClick().GoToRepositoriesPage();
        }

        internal static bool ContainsRepository(string repositoryName) => GoToRepositorisePage(false).ContainsRepository(repositoryName);

        internal static RepositoriesPage DeleteRepository(RepositoryPageView repositoryPage)
        {
            return repositoryPage.JumpToSettings().DeleteThisRepository().SetVerify().Submit();
        }
    }
}
