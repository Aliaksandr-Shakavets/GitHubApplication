using System;
using RestAPITests.Dal;

namespace RestAPITests.Services
{
    internal class GuardService
    {
        public virtual void Protect(IRepositoryRequestBody repository)
        {
            if (repository is null)
            {
                throw new ArgumentNullException(nameof(repository));
            }
        }

        public virtual void Protect(IRepositoryContext repository)
        {
            if (repository is null)
            {
                throw new ArgumentNullException(nameof(repository));
            }
        }

        internal virtual void Protect(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException($"'{nameof(name)}' cannot be null or empty", nameof(name));
            }
        }
    }
}