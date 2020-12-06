using System.Collections.Generic;
using System.Threading.Tasks;
using RestAPITests.Dal;

namespace RestAPITests.Controllers
{
    internal interface IRepositoryController : IController
    {
        public IAuthenticationController AuthController { get; }
        Task<ICollection<RepositoryContext>> GetRepositoriesAsync();
        Task<RepositoryContext> AddRepositoryAsync(RepositoryRequestBody repository);
        Task<BrancheContext> AddBrancheAsync(RepositoryContext repository, string brancheName);
        Task<ICollection<BrancheContext>> GetBranches(RepositoryContext repository);
    }
}