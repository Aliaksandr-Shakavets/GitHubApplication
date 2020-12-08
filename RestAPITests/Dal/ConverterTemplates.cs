using System;
using ServiceStack;
using ServiceStack.Text;

namespace RestAPITests.Dal
{
    internal class ConverterTemplates
    {
        public virtual Func<JsonObject, IRepositoryContext> ToRepository => (content) =>
        {
            return content.ConvertTo<RepositoryContext>();
        };

        public virtual Func<JsonObject, IExceptionMessage> ToExceptionMessage => (content) =>
        {
            var exceptionMessage = content.ConvertTo(new ExceptionMessage());
            if (content.Count > 2)
            {
                exceptionMessage.Details = content["errors"].Trim(new char[] { '[', ']' }).ConvertTo<ErrorDetails>();
            }

            return exceptionMessage;
        };
        public virtual Func<JsonObject, IBrancheContext> ToBranch => (content) =>
        {
            var branch = content.ConvertTo(new BrancheContext());
            branch.Details = content["object"].Trim(new char[] { '[', ']' }).ConvertTo<BranchDetails>();

            return branch;
        };
    }
}
