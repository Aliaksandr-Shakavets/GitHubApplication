using NUnit.Framework;
using OpenQA.Selenium;
using Tests.Core;
using Tests.Core.Data_access_layer;
using UserInterfaceTests.Logic_steps;

namespace UserInterfaceTests
{
    [TestFixture]
    public class MainTests : BaseUiTests
    {
        [Test]
        public void CheckSuccessfulSignInByAccountName_ProfileNickNameEqualsLogin_TrueReturned()
        {
            var accountNameLocator = By.XPath("//span[@itemprop='additionalName']");
            var expected = AppSettings.Login;

            AuthenticationSteps.SignIn()
                .DropDownCaretClick()
                .GoToProfilePage();

            var actual = webDriver.GetVisibleElement(accountNameLocator).Text;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CheckCreatingNewRepositories_RepositoryPageWillExistNewRepository_TrueReturned()
        {
            var generatedRepositoryName = TestExtensions.GetRandomString(length: 8);
            var repositoryForm = new RepositoryFormInfo()
            {
                Name = generatedRepositoryName,
                Description = "test creating repository",
                NeedToAddReadmi = true,
                Visibility = Visibility.Private,
                NeedToAddGitIgnore = true,
                GitIgnoreTemplate = "VisualStudio",
            };

            RepositoriesSteps.CreateNewRepository(repositoryForm);
            var actual = RepositoriesSteps.ContainsRepository(generatedRepositoryName);

            Assert.True(actual);
        }

        [Test]
        public void DeleteCreatedRepository_RepositoryDeletedFromAccount_FalseReturned()
        {
            var generatedRepositoryName = TestExtensions.GetRandomString(length: 8);
            var repositoryForm = new RepositoryFormInfo()
            {
                Name = generatedRepositoryName,
                Description = "test creating and deleting",
                NeedToAddReadmi = true,
                Visibility = Visibility.Private,
                NeedToAddGitIgnore = true,
                GitIgnoreTemplate = "VisualStudio",
            };

            var newRepository = RepositoriesSteps.CreateNewRepository(repositoryForm);
            RepositoriesSteps.DeleteRepository(newRepository);
            var actual = RepositoriesSteps.ContainsRepository(generatedRepositoryName);

            Assert.False(actual);
        }

        [Test]
        public void CreateNewProject_ProjectPageWillExistNewProjectAsOpen_TrueReturned()
        {
            var generatedRepositoryName = TestExtensions.GetRandomString(length: 6);
            var projectForm = new ProjectFormInfo()
            {
                Name = generatedRepositoryName,
                Description = "test creating",
                Visibility = Visibility.Public,
            };

            ProjectsSteps.CreateNewProject(projectForm);
            var actual = ProjectsSteps.ContainsOpenProject(generatedRepositoryName);

            Assert.True(actual);
        }

        [Test]
        public void CloseCreatedProject_NewProjectWillExistInClosedProjectsAndUnexistsInOpenProjects_TrueReturned()
        {
            var generatedProjectName = TestExtensions.GetRandomString(length: 6);
            var projectForm = new ProjectFormInfo()
            {
                Name = generatedProjectName,
                Description = "this project needs to be moved to closed projects",
                Visibility = Visibility.Public,
            };

            ProjectsSteps.CreateNewProject(projectForm);
            ProjectsSteps.CloseProject(generatedProjectName);
            var actual = ProjectsSteps.ContainsClosedProject(generatedProjectName) && !ProjectsSteps.ContainsOpenProject(generatedProjectName);

            Assert.True(actual);
        }
    }
}