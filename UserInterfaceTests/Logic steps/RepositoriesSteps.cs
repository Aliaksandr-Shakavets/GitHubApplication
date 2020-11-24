using Tests.Core;
using UserInterfaceTests.Pages;

namespace UserInterfaceTests.Logic_steps
{
    internal static class RepositoriesSteps
    {
        internal static RepositoriesPage CreateNewRepository(string repositoryName = default)
        {
            var repoName = string.IsNullOrEmpty(repositoryName) ? TestExtensions.GetRandomString(8) : repositoryName;

            return GoToRepositorisePage()
                .ClickToNewRepository()
                .SetName(repoName)
                .SetDescriptions(TestExtensions.GetRandomString(18))
                .SetVisibility(isPublic: false)
                .AddReadmeRadioButton()
                .AddGitIgnore()
                .AddGitIgnoreTemplate()
                .SetIgnoreFilter("VisualStudio")
                .Submit();
        }

        internal static RepositoriesPage GoToRepositorisePage()
        {
            return AuthenticationSteps.Invoke()
                .DropDownCaretClick()
                .GoToRepositoriesPage();
        }
    }
}
