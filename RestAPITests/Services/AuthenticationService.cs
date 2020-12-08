using System;
using System.Threading.Tasks;
using RestAPITests.Dal;
using RestSharp;

namespace RestAPITests.Services
{
    internal class AuthenticationService : IAuthenticationService
    {
        public IRestApiService ApiService { get; }
        public IContentConverterService Converter { get; }

        public AuthenticationService(IRestApiService apiService, IContentConverterService converter)
        {
            Converter = converter ?? throw new ArgumentNullException(nameof(converter));
            ApiService = apiService ?? throw new ArgumentNullException(nameof(apiService));
        }

        public async Task<IUserContext> SignIn()
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
