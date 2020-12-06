using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;
using RestAPITests.Dal;
using RestAPITests.Services;
using ServiceStack;

namespace RestAPITests.Controllers
{
    internal class RepositoryController : IRepositoryController
    {
        public IRestApiService ApiService { get; }
        public IAuthenticationController AuthController { get; }
        public IContentConverterService Converter { get; }

        public RepositoryController(IRestApiService apiService, IAuthenticationController auth, IContentConverterService converter)
        {
            AuthController = auth ?? throw new ArgumentNullException(nameof(auth));
            Converter = converter ?? throw new ArgumentNullException(nameof(converter));
            ApiService = apiService ?? throw new ArgumentNullException(nameof(apiService));
        }

        public async Task<ICollection<RepositoryContext>> GetRepositoriesAsync()
        {
            var request = new RestRequest()
            {
                Resource = "user/repos",
                Method = Method.GET,
            };
            var responce = await ApiService.ExecuteRequest(request);

            return Converter.ConvertToRepoitories(responce.Content);
        }

        public async Task<RepositoryContext> AddRepositoryAsync(RepositoryRequestBody repository)
        {
            if (repository is null)
            {
                throw new ArgumentNullException(nameof(repository));
            }

            var jsonRequestBody = repository.ToJson();
            var request = new RestRequest()
            {
                Resource = "user/repos",
                Method = Method.POST,
            };
            request.AddJsonBody(jsonRequestBody);
            var responce = await ApiService.ExecuteRequest(request);

            return Converter.ConvertToRepository(responce.Content);
        }

        public async Task<BrancheContext> AddBrancheAsync(RepositoryContext repository, string brancheName)
        {
            if (repository is null)
            {
                throw new ArgumentNullException(nameof(repository));
            }

            if (string.IsNullOrEmpty(brancheName))
            {
                throw new ArgumentException($"'{nameof(brancheName)}' cannot be null or empty", nameof(brancheName));
            }

            var sha = await GetRepositoryCommitsSha(repository);
            var requestBody = new NewBrancheRequestBody()
            {
                Ref = brancheName,
                Sha = sha,
            }.ToJson();
            var request = new RestRequest()
            {
                Resource = $"repos/{repository.FullName}/git/refs",
                Method = Method.POST,
            };
            request.AddJsonBody(requestBody);
            var responce = await ApiService.ExecuteRequest(request);

            return Converter.ConvertToBranches(responce.Content).FirstNonDefault();
        }

        public async Task<ICollection<BrancheContext>> GetBranches(RepositoryContext repository)
        {
            if (repository is null)
            {
                throw new ArgumentNullException(nameof(repository));
            }

            var request = new RestRequest()
            {
                Resource = $"repos/{repository.FullName}/git/refs",
                Method = Method.GET,
            };
            var responce = await ApiService.ExecuteRequest(request);

            return Converter.ConvertToBranches(responce.Content);
        }

        private async Task<string> GetRepositoryCommitsSha(RepositoryContext repository)
        {
            var getCommitsRequest = new RestRequest()
            {
                Resource = $"repos/{repository.FullName}/commits",
                Method = Method.GET,
            };

            var responce = await ApiService.ExecuteRequest(getCommitsRequest);
            return Converter.GetShaValue(responce.Content);
        }
    }
}
