using RestSharp.Authenticators;
using System;

namespace RestAPITests
{
    public interface IClient
    {
        public Uri BaseUri { get; }

        public IAuthenticator Authenticator { get;}
    }
}
