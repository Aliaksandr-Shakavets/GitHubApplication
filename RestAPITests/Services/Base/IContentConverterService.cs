using RestAPITests.Dal;
using System.Collections.Generic;

namespace RestAPITests.Services
{
    internal interface IContentConverterService
    {
        ConverterTemplates Templates { get; }

        ICollection<IRepositoryContext> ConvertToRepoitories(string content);
        IUserContext ConvertToUser(string content);
        IRepositoryContext ConvertToRepository(string content);
        string GetShaValue(string content);
        ICollection<IBrancheContext> ConvertToBranches(string content);
        IExceptionMessage ConvertToExceptionMessage(string content);
    }
}