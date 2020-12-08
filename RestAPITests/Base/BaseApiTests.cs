using System.Threading.Tasks;
using NUnit.Framework;
using RestAPITests.Dal;
using RestAPITests.Services;
using RestAPITests.Controllers;

namespace RestAPITests
{
    internal class BaseApiTests
    {
        public IClient Client { get; private set; }
        public IRestApiService ApiService { get; private set; }
        public IContentConverterService Converter { get; private set; }
        public IRepositoryController RepositoryController { get; private set; }
        public IAuthenticationController AuthenticationController { get; private set; }

        [OneTimeSetUp]
        public void SetUp()
        {
            var guard = new GuardService();
            Client = new GithubClient();
            Converter = new ContentConverterService(new ConverterTemplates(), guard);
            ApiService = new RestApiService(Client, Converter);
            AuthenticationController = new AuthenticationController(new AuthenticationService(ApiService, Converter));
            RepositoryController = new RepositoryController(AuthenticationController, new RepositoryService(ApiService, Converter, guard));
        }

        [OneTimeTearDown]
        public async Task RemoveAllCreatedRepositoriesAsync() => await RepositoryController.RemoveAllCreatedRepositoriesAsync();
    }
}