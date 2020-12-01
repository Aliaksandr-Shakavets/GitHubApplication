﻿using Tests.Core.Data_access_layer;
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

        internal static RepositoriesPage GoToRepositorisePage()
        {
            return AuthenticationSteps.SignIn()
                .DropDownCaretClick()
                .GoToRepositoriesPage();
        }

        internal static bool ContainsRepository(string repositoryName) => new Footer().DropDownCaretClick().GoToRepositoriesPage().ContainsRepository(repositoryName);

        internal static RepositoriesPage DeleteRepository(RepositoryPageView repositoryPage)
        {
            return repositoryPage.JumpToSettings().DeleteThisRepository().SetVerify().Submit();
        }
    }
}