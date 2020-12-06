using RestSharp;
using System.Threading.Tasks;

namespace RestAPITests.Services
{
    public interface IRestApiService
    {
        Task<IRestResponse> ExecuteRequest(IRestRequest request);
    }
}