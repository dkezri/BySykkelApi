using System.Net.Http;
using Xunit;

namespace OsloBySykkelApiTests.Core
{
    public class TestBase : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly CustomWebApplicationFactory _webApplicationFactory;
        protected readonly HttpClient _httpClient;
        protected TestBase(CustomWebApplicationFactory webApplicationFactory)
        {
            _webApplicationFactory = webApplicationFactory;
            _httpClient = _webApplicationFactory.CreateClient();
        }
    }
}