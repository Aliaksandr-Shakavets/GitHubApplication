using NUnit.Framework;
using OpenQA.Selenium;
using TestsFeatures;
using UserInterfaceTests.Pages;

namespace UserInterfaceTests
{
    [TestFixture]
    public class Tests : BaseUiTests
    {
        [Test]
        public void TryToSignIn_SuccessfulLogin_DoesNotThrowException()
        {
            var indexPage = new IndexPage(webDriver);
            Assert.DoesNotThrow(() => { indexPage.ClickToSigInBtton().SignIn(); });
        }

        [Test]
        public void CheckPageTransitionToUserProfile_LocatorsTextEqualsTestAccountAutomation_TrueReturned()
        {
            var accountNameLocator = By.XPath("//span[@itemprop='additionalName']");
            var expected = GitHubFeatures.Default.Login;

            new IndexPage(webDriver).ClickToSigInBtton()
                .SignIn().ClickDropDownCaret().GoToProfilePage();

            var actual = webDriver.FindElement(accountNameLocator).Text;

            Assert.AreEqual(expected, actual, "You don't found the user profile page");
        }

        [Test]
        public void CheckCreatingNewProjectForm_NewProjectPageHasToOpens_DoesNotThrowException()
        {
            var projectPage = new IndexPage(webDriver).ClickToSigInBtton()
                .SignIn().ClickDropDownCaret().GoToProjectsPage();

            Assert.DoesNotThrow(() => projectPage.GoToNewProjectForm());
        }

        [Test]
        public void CreateNewProjectWithValidatedName_NewProjectWillCreated_DoesNotThrowException()
        {
            Assert.DoesNotThrow(() => new IndexPage(webDriver).ClickToSigInBtton()
            .SignIn().ClickDropDownCaret().GoToProjectsPage().GoToNewProjectForm().CreateNewProject());
        }

        [Test]
        public void CreateNewProjectWithEmptyName_NewProjectWillNotCreated_ThrowExceptionNoSuchElementException()
        {
            Assert.Throws<NoSuchElementException>(() => new IndexPage(webDriver).ClickToSigInBtton()
            .SignIn().ClickDropDownCaret().GoToProjectsPage()
            .GoToNewProjectForm().CreateNewProject(canBeProjectNameIsEmpty: true));
        }

        [Test]
        public void CreateNewRepositoryWithReadmeFile_NewRepositoryWillCreated_DoesNotThrowException()
        {
            Assert.DoesNotThrow(() => new IndexPage(webDriver).ClickToSigInBtton()
            .SignIn().ClickDropDownCaret()
            .GoToRepositoriesPage().ClickToNewRepository()
            .CreateNewRepository(isPublicVisibility: false));
        }

        [Test]
        public void CreateNewRepositoryWithGitIgnoreTemplate_NewRepositoryWillCreated_DoesNotThrowException()
        {
            Assert.DoesNotThrow(() => new IndexPage(webDriver).ClickToSigInBtton()
            .SignIn().ClickDropDownCaret()
            .GoToRepositoriesPage().ClickToNewRepository()
            .CreateNewRepository(isPublicVisibility: true, needAddReadme: false, gitIgnoreTemplate: "VisualStudio"));
        }
    }
}
