using UserInterfaceTests.Pages_Elements;

namespace UserInterfaceTests.Pages
{
    internal class ProfileAreaMenu
    {
        private readonly ProfileAreaMenuElements menuElements = new ProfileAreaMenuElements();

        public UserProfilePage GoToProfilePage()
        {
            var profileButton = menuElements.GetProfileButton();
            profileButton.Click();

            return new UserProfilePage();
        }

        public RepositoriesPage GoToRepositoriesPage()
        {
            var repositoryButton = menuElements.GetRepositoriesButton();
            repositoryButton.Click();

            return new RepositoriesPage();
        }

        public ProjectsPage GoToProjectPage()
        {
            var projectButton = menuElements.GetProjectsButton();
            projectButton.Click();

            return new ProjectsPage();
        }

        public IndexPage SignOut()
        {
            var signOutButton = menuElements.GetSignOutButton();
            signOutButton.Click();

            return new IndexPage();
        }
    }
}