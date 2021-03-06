﻿using RestAPITests.Dal;
using RestAPITests.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestAPITests.Controllers
{
    internal interface IRepositoryController
    {
        IAuthenticationController AuthController { get; }
        IRepositoryService RepositoryService { get; set; }

        Task<IBrancheContext> AddBrancheAsync(IRepositoryContext repository, string brancheName);
        Task<IRepositoryContext> AddRepositoryAsync(IRepositoryRequestBody repository);
        Task<ICollection<IBrancheContext>> GetBranchesAsync(IRepositoryContext repository);
        Task<ICollection<IRepositoryContext>> GetRepositoriesAsync();
        Task RemoveAllCreatedRepositoriesAsync();
    }
}