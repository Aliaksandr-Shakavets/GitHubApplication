using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ServiceStack;
using RestAPITests.Dal;
using RestSharp;

namespace RestAPITests.Services
{
    internal class RepositoryService : IRepositoryService
    {
        public IRestApiService ApiService { get; }
        public IContentConverterService Converter { get; }

        public GuardService Guard { get; }

        public RepositoryService(IRestApiService apiService, IContentConverterService converter, GuardService guard)
        {
            Converter = converter ?? throw new ArgumentNullException(nameof(converter));
            ApiService = apiService ?? throw new ArgumentNullException(nameof(apiService));
            Guard = guard ?? throw new ArgumentNullException(nameof(guard));
        }

        public async Task<ICollection<IRepositoryContext>> GetRepositoriesAsync()
        {
            var request = new RestRequest()
            {
                Resource = "user/repos",
                Method = Method.GET,
            };
            var responce = await ApiService.ExecuteRequest(request);

            return Converter.ConvertToRepoitories(responce.Content);
        }

        public async Task<IRepositoryContext> AddRepositoryAsync(IRepositoryRequestBody repository)
        {
            Guard.Protect(repository);

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

        public async Task<IBrancheContext> AddBrancheAsync(IRepositoryContext repository, string brancheName)
        {
            Guard.Protect(repository);
            Guard.Protect(brancheName);

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

        public async Task<ICollection<IBrancheContext>> GetBranchesAsync(IRepositoryContext repository)
        {
            Guard.Protect(repository);

            var request = new RestRequest()
            {
                Resource = $"repos/{repository.FullName}/git/refs",
                Method = Method.GET,
            };
            var responce = await ApiService.ExecuteRequest(request);

            return Converter.ConvertToBranches(responce.Content);
        }

        public async Task RemoveAllCreatedRepositoriesAsync()
        {
            var repositories = await GetRepositoriesAsync();

            foreach (var repository in repositories)
            {
                var request = new RestRequest()
                {
                    Resource = $"repos/{repository.FullName}",
                    Method = Method.DELETE,
                };

                await ApiService.ExecuteRequest(request);
            }
        }

        private async Task<string> GetRepositoryCommitsSha(IRepositoryContext repository)
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
