using RestAPITests.Dal;
using System.Collections.Generic;

namespace RestAPITests.Services
{
    internal interface IContentConverterService
    {
        ICollection<RepositoryContext> ConvertToRepoitories(string content);
        UserContext ConvertToUser(string content);
        RepositoryContext ConvertToRepository(string content);
        string GetShaValue(string content);
        ICollection<BrancheContext> ConvertToBranches(string content);
    }
}