using System;
using System.Collections.Generic;
using System.Linq;
using RestAPITests.Dal;
using ServiceStack;
using ServiceStack.Text;

namespace RestAPITests.Services
{
    internal class ContentConverterService : IContentConverterService
    {
        private Func<JsonObject, RepositoryContext> ToRepository => (content) =>
         {
             return content.ConvertTo<RepositoryContext>();
         };
        private Func<JsonObject, ExceptionMessage> ToExceptionMessage => (content) =>
        {
            var exceptionMessage = content.ConvertTo(new ExceptionMessage());
            if (content.Count > 2)
            {
                exceptionMessage.Details = content["errors"].Trim(new char[] { '[', ']' }).ConvertTo<ErrorDetails>();
            }

            return exceptionMessage;
        };
        private Func<JsonObject, BrancheContext> ToBranch => (content) =>
        {
            var branch = content.ConvertTo(new BrancheContext());
            branch.Details = content["object"].Trim(new char[] { '[', ']' }).ConvertTo<BranchDetails>();

            return branch;
        };

        public ICollection<RepositoryContext> ConvertToRepoitories(string content)
        {
            ContentGuard(content);
            var repositories = JsonArrayObjects.Parse(content).ConvertAll(ToRepository);

            return repositories;
        }

        public RepositoryContext ConvertToRepository(string content)
        {
            ContentGuard(content);
            var repository = JsonArrayObjects.Parse(content).First().ConvertTo<RepositoryContext>();

            return repository;
        }

        public ICollection<BrancheContext> ConvertToBranches(string content)
        {
            ContentGuard(content);
            var branches = JsonArrayObjects.Parse(content).ConvertAll(ToBranch);

            return branches;
        }

        public UserContext ConvertToUser(string content)
        {
            ContentGuard(content);
            var user = JsonArrayObjects.Parse(content).First().ConvertTo<UserContext>();
            return user;
        }

        public ExceptionMessage ConvertToExceptionMessage(string content)
        {
            ContentGuard(content);
            var exceptionMessage = JsonArrayObjects.Parse(content).ConvertAll(ToExceptionMessage).First();

            return exceptionMessage;
        }

        public string GetShaValue(string content)
        {
            ContentGuard(content);

            return JsonArrayObjects.Parse(content).ConvertAll((c) => c["sha"]).First();
        }

        private static void ContentGuard(string content)
        {
            if (string.IsNullOrEmpty(content))
            {
                throw new ArgumentNullException(nameof(content));
            }
        }
    }
}
