using Tests.Core.Data_access_layer;
using UserInterfaceTests.Pages;

namespace UserInterfaceTests.Logic_steps
{
    internal static class RepositoriesSteps
    {
        internal static RepositoriesPage CreateNewRepository(RepositoryFormInfo repositoryForm)
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

        internal static RepositoriesPage GoToRepositorisePage()
        {
            return AuthenticationSteps.SignIn()
                .DropDownCaretClick()
                .GoToRepositoriesPage();
        }
    }
}
