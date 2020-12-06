using System.Threading.Tasks;
using RestAPITests.Dal;

namespace RestAPITests.Controllers
{
    internal interface IAuthenticationController : IController
    {
        Task<UserContext> SignIn();
    }
}