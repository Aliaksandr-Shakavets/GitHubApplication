using RestAPITests.Dal;
using RestAPITests.Services;
using System.Threading.Tasks;

namespace RestAPITests.Controllers
{
    internal interface IAuthenticationController
    {
        IAuthenticationService AuthService { get; }

        Task<IUserContext> SignIn();
    }
}