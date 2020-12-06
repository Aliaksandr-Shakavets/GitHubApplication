using System;
using System.Threading.Tasks;
using RestSharp;
using ServiceStack.Host;

namespace RestAPITests.Services
{
    public class RestApiService : IRestApiService
    {
        private readonly IRestClient restClient;

        public RestApiService(IClient client)
        {
            restClient = new RestClient()
            {
                BaseUrl = client.BaseUri,
                Authenticator = client.Authenticator,
            };
        }

        public async Task<IRestResponse> ExecuteRequest(IRestRequest request)
        {
            Guard(request);
            var response = await restClient.ExecuteAsync(request);
            if (!response.IsSuccessful)
            {
                var exception = new ContentConverterService().ConvertToExceptionMessage(response.Content);

                throw new HttpException($"Status code: {(int)response.StatusCode}\n " +
                    $"message: '{exception.Message}'\n" +
                    $"details: field: '{exception.Details?.Field}', details message: '{exception.Details?.Message}'");
            }

            return response;
        }

        private static void Guard(IRestRequest request)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }
        }
    }
}
