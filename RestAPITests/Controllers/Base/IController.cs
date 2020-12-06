using RestAPITests.Services;

namespace RestAPITests.Controllers
{
    internal interface IController
    {
        public IRestApiService ApiService { get; }
        public IContentConverterService Converter { get; }
    }
}
