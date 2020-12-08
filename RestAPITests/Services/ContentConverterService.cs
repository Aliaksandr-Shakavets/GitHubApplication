using System;
using System.Collections.Generic;
using System.Linq;
using RestAPITests.Dal;
using ServiceStack.Text;

namespace RestAPITests.Services
{
    internal class ContentConverterService : IContentConverterService
    {
        public ConverterTemplates Templates { get; }

        public GuardService Guard { get; }

        public ContentConverterService(ConverterTemplates converterTemplates, GuardService guardService)
        {
            Templates = converterTemplates ?? throw new ArgumentNullException(nameof(converterTemplates));
            Guard = guardService ?? throw new ArgumentNullException(nameof(guardService));
        }
        public ICollection<IRepositoryContext> ConvertToRepoitories(string content)
        {
            Guard.Protect(content);
            var repositories = JsonArrayObjects.Parse(content).ConvertAll(Templates.ToRepository);

            return repositories;
        }

        public IRepositoryContext ConvertToRepository(string content)
        {
            Guard.Protect(content);
            var repository = JsonArrayObjects.Parse(content).First().ConvertTo<RepositoryContext>();

            return repository;
        }

        public ICollection<IBrancheContext> ConvertToBranches(string content)
        {
            Guard.Protect(content);
            var branches = JsonArrayObjects.Parse(content).ConvertAll(Templates.ToBranch);

            return branches;
        }

        public IUserContext ConvertToUser(string content)
        {
            Guard.Protect(content);
            var user = JsonArrayObjects.Parse(content).First().ConvertTo<UserContext>();
            return user;
        }

        public IExceptionMessage ConvertToExceptionMessage(string content)
        {
            Guard.Protect(content);
            var exceptionMessage = JsonArrayObjects.Parse(content).ConvertAll(Templates.ToExceptionMessage).First();

            return exceptionMessage;
        }

        public string GetShaValue(string content)
        {
            Guard.Protect(content);

            return JsonArrayObjects.Parse(content).ConvertAll((c) => c["sha"]).First();
        }
    }
}
