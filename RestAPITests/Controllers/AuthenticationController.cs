using System;
using System.Threading.Tasks;
using RestSharp;
using RestAPITests.Services;
using RestAPITests.Dal;

namespace RestAPITests.Controllers
{
    internal class AuthenticationController : IAuthenticationController
    {
        public IRestApiService ApiService { get; }
        public IContentConverterService Converter { get; }

        public AuthenticationController(IRestApiService apiService, IContentConverterService converter)
        {
            Converter = converter ?? throw new ArgumentNullException(nameof(converter));
            ApiService = apiService ?? throw new ArgumentNullException(nameof(apiService));
        }       

        public async Task<UserContext> SignIn()
        {
            var request = new RestRequest()
            {
                Resource = "user",
                Method = Method.GET,
            };
            var responce = await ApiService.ExecuteRequest(request);

            return Converter.ConvertToUser(responce.Content);
        }
    }
}
