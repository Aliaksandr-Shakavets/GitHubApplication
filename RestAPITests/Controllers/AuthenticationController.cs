using System;
using System.Threading.Tasks;
using RestAPITests.Services;
using RestAPITests.Dal;

namespace RestAPITests.Controllers
{
    internal class AuthenticationController : IAuthenticationController
    {
        public IAuthenticationService AuthService { get; }

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            AuthService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
        }
        public async Task<IUserContext> SignIn() => await AuthService.SignIn();
    }
}
