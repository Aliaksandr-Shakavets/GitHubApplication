using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using RestAPITests.Dal;
using Tests.Core;

namespace RestAPITests
{
    internal class Tests : BaseApiTests
    {
        [Test]
        public async Task CheckSuccessfulSignIn_ResponceLoginEqualsSettingsLogin_TrueReturned()
        {
            var expected = AppSettings.Login;
            var user = await AuthenticationController.SignIn();
            var actual = user.Login;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public async Task CheckSuccessfulCreatingNewRepository_NewRepositoryShouldBeCreated_TrueReturned()
        {
            var newRepository = new RepositoryRequestBody()
            {
                Name = TestExtensions.GetRandomString(5),
                Description = "that repository was created with rest api service",
                AutoInit = true,
                IsPrivate = false,
                GitIgnoreTemplate = "VisualStudio",
            };

            var repository = await RepositoryController.AddRepositoryAsync(newRepository);
            var repositories = (await RepositoryController.GetRepositoriesAsync()).ToList();

            Assert.Contains(repository, repositories);
        }

        [Test]
        public async Task CheckSuccessfulCreatingNewBranche_NewBranchShouldBeCreated_TrueReturned()
        {
            var newRepository = new RepositoryRequestBody()
            {
                Name = TestExtensions.GetRandomString(5),
                Description = "that repository was created with rest api service for creating new branch",
                AutoInit = true,
                IsPrivate = true,
                GitIgnoreTemplate = "VisualStudio",
            };

            var repository = await RepositoryController.AddRepositoryAsync(newRepository);
            var branch = await RepositoryController.AddBrancheAsync(repository, "new-test-branch");
            var branches = (await RepositoryController.GetBranches(repository)).ToList();

            Assert.Contains(branch, branches);
        }
    }
}
