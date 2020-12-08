using RestAPITests.Dal;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestAPITests.Services
{
    internal interface IRepositoryService
    {
        IRestApiService ApiService { get; }
        IContentConverterService Converter { get; }

        Task<IBrancheContext> AddBrancheAsync(IRepositoryContext repository, string brancheName);
        Task<IRepositoryContext> AddRepositoryAsync(IRepositoryRequestBody repository);
        Task<ICollection<IBrancheContext>> GetBranchesAsync(IRepositoryContext repository);
        Task<ICollection<IRepositoryContext>> GetRepositoriesAsync();
        Task RemoveAllCreatedRepositoriesAsync();
    }
}