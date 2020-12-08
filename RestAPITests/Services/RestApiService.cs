using System;
using System.Threading.Tasks;
using RestSharp;
using ServiceStack.Host;

namespace RestAPITests.Services
{
    internal class RestApiService : IRestApiService
    {
        public IRestClient RestClient { get; }

        public IContentConverterService Converter { get; }

        public RestApiService(IClient client, IContentConverterService contentConverterService)
        {
            if (client is null)
            {
                throw new ArgumentNullException(nameof(client));
            }

            Converter = contentConverterService ?? throw new ArgumentNullException(nameof(contentConverterService));
            RestClient = new RestClient()
            {
                BaseUrl = client.BaseUri,
                Authenticator = client.Authenticator,
            };
        }

        public async Task<IRestResponse> ExecuteRequest(IRestRequest request)
        {
            Guard(request);
            var response = await RestClient.ExecuteAsync(request);
            if (!response.IsSuccessful)
            {
                var exception = Converter.ConvertToExceptionMessage(response.Content);

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
