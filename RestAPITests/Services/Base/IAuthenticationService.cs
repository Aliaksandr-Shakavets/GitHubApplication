using RestAPITests.Dal;
using System.Threading.Tasks;

namespace RestAPITests.Services
{
    internal interface IAuthenticationService
    {
        IRestApiService ApiService { get; }
        IContentConverterService Converter { get; }

        Task<IUserContext> SignIn();
    }
}