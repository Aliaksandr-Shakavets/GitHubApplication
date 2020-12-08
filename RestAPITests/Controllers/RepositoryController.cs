using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestAPITests.Dal;
using RestAPITests.Services;

namespace RestAPITests.Controllers
{
    internal class RepositoryController : IRepositoryController
    {
        public IAuthenticationController AuthController { get; }
        public IRepositoryService RepositoryService { get; set; }

        public RepositoryController(IAuthenticationController auth, IRepositoryService repositoryService)
        {
            AuthController = auth ?? throw new ArgumentNullException(nameof(auth));
            RepositoryService = repositoryService ?? throw new ArgumentNullException(nameof(repositoryService));
        }

        public async Task<ICollection<IRepositoryContext>> GetRepositoriesAsync() => await RepositoryService.GetRepositoriesAsync();

        public async Task<IRepositoryContext> AddRepositoryAsync(IRepositoryRequestBody repository) => await RepositoryService.AddRepositoryAsync(repository);

        public async Task<IBrancheContext> AddBrancheAsync(IRepositoryContext repository, string brancheName) => await RepositoryService.AddBrancheAsync(repository, brancheName);

        public async Task<ICollection<IBrancheContext>> GetBranchesAsync(IRepositoryContext repository) => await RepositoryService.GetBranchesAsync(repository);

        public async Task RemoveAllCreatedRepositoriesAsync() => await RepositoryService.RemoveAllCreatedRepositoriesAsync();
    }
}
