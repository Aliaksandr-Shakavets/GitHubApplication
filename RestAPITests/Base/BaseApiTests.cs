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

        [SetUp]
        public void SetUp()
        {
            Client = new GithubClient();
            ApiService = new RestApiService(Client);
            Converter = new ContentConverterService();
            AuthenticationController = new AuthenticationController(ApiService, Converter);
            RepositoryController = new RepositoryController(ApiService, AuthenticationController, Converter);
        }        
    }
}