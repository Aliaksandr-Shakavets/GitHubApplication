using System;
using Tests.Core;
using RestSharp.Authenticators;

namespace RestAPITests.Dal
{
    internal class GithubClient : IClient
    {
        public Uri BaseUri => new Uri(@"https://api.github.com");

        public IAuthenticator Authenticator => new HttpBasicAuthenticator(AppSettings.Login, AppSettings.PersonalAccessToken);
    }
}
